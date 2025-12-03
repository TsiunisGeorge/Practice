--1. Вывести список всех клиентов из города Минск.
SELECT
    customer_id, customer_name
FROM
    customers
WHERE
    city = 'Минск';

--2. Вывести названия и цены всех товаров, отсортированных по убыванию цены.
SELECT
    product_id, product_name, price
FROM
    products
ORDER BY
    price DESC;

--3. Посчитать общее количество клиентов в базе данных.
SELECT
    COUNT(*)
FROM
    customers;

--4. Найти общую сумму всех заказов.
SELECT
    SUM(total_amount)
FROM
    orders;

--5. Вывести список всех заказов с указанием имени клиента и даты заказа.
SELECT
    C.customer_id, C.customer_name, O.*
FROM
    orders AS O
JOIN
    customers AS C ON O.customer_id=C.customer_id;

--6. Найти общую сумму потраченных средств для каждого клиента. Вывести имя клиента и общую сумму.
SELECT
    C.customer_id, C.customer_name,
    SUM(o.total_amount)
FROM
    customers AS C
JOIN
    orders AS O ON C.customer_id = O.customer_id
GROUP BY
    C.customer_name;


--7. Вывести имена клиентов, которые сделали заказ после '2023-10-01'.
SELECT
    C.customer_id, C.customer_name
FROM
    customers AS C
JOIN
    orders AS O ON O.order_date > '2023-10-01'
GROUP BY
    C.customer_name;

--8. Найти клиентов, общая сумма заказов которых превышает 10000.
SELECT
    C.customer_id, C.customer_name
FROM
    customers AS C
JOIN
    orders AS O ON C.customer_id = O.customer_id
GROUP BY
    C.customer_name
HAVING
    SUM(O.total_amount)>10000;

--9. Вывести для каждого клиента его заказы, отсортированные по дате, и добавить столбец с номером заказа по порядку для каждого клиента (ранг).
SELECT
    c.customer_name,
    o.order_date,
    o.total_amount,
    ROW_NUMBER() OVER (
        PARTITION BY c.customer_id
        ORDER BY o.order_date)
FROM
    customers c
JOIN
    orders o ON c.customer_id = o.customer_id
ORDER BY
    c.customer_name,
    o.order_date;

--10. Для каждого заказа вывести его дату и дату предыдущего заказа этого же клиента.
SELECT
    c.customer_name,
    o.order_date,
    o.total_amount,
    LAG(o.order_date) OVER (
        PARTITION BY c.customer_id
        ORDER BY o.order_date)
FROM
    customers c
JOIN
    orders o ON c.customer_id = o.customer_id
ORDER BY
    c.customer_name,
    o.order_date;

--11. Найти клиентов с одинаковыми именами в одном городе.
SELECT
    customer_name,
    city,
    COUNT(customer_id)
FROM
    customers
GROUP BY
    customer_name, city
HAVING
    COUNT(customer_id) > 1;

--12. Вывести заказы с нарастающим итогом суммы заказов по месяцам.

--13. Найти клиентов, которые купили *все* товары из категории 'Электроника'.
--*(Предположим, у нас есть таблица `order_items` с `order_id`, `product_id` и `quantity`)*.

--14. Найти товар с наибольшим количеством продаж (по штукам) в каждой категории.
