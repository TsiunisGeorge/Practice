SELECT DISTINCT
    Emp.employee_id AS manager_id
FROM
    Employees AS Emp
JOIN
    Roles AS R ON Emp.role_id = R.role_id
WHERE
    R.role_name LIKE '%Manager%'
LIMIT 100;
 -- предполагаю что бывают составные менеджерские роли

SELECT DISTINCT
    CONCAT(first_name, '(', job_title, ')') AS employee_info
FROM
    Employees AS Emp
JOIN
    Jobs AS J ON Emp.job_id = J.job_id
LIMIT 100;
