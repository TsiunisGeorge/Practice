// Вариант 3
// Создайте массив из 12 случайных целых чисел в диапазоне от 0 до 100.
// Отсортируйте массив по убыванию (от большего к меньшему) и выведите результат.
// Найдите индекс первого вхождения числа 50 (если оно есть в массиве).

int[] arr = new int[12];
for (int i = 0; i < arr.Length; i++){
    arr[i] = Random.Shared.Next();
}

arr = arr.OrderBy(n => n).ToArray();
int index = Array.BinarySearch(arr, 50);
if (index != -1) {
    Console.Write(index);
}