using System.Timers;

int[] numbers = DrawNumbersArray();
var numbers1 = new int[numbers.Length];
for (int i = 0; i < numbers.Length; i++)
{
    numbers1[i] = numbers[i];
}


Console.WriteLine($"\nTablica początkowa [{numbers.Length}]: \n");
DisplayArray(numbers);

QuickSort(numbers, 0, numbers.Length - 1);
Console.WriteLine($"\n\n\nSortowanie szybkie");
Console.WriteLine($"Tablica wynikowa [{numbers.Length}]:\n");
DisplayArray(numbers);

BubbleSort(numbers1);
Console.WriteLine($"\n\n\nSortowanie bąbelkowe");
Console.WriteLine($"Tablica wynikowa [{numbers1.Length}]:\n");
DisplayArray(numbers1);

void QuickSort(int[] numbers, int begin, int end)
{
    if (end > begin)
    {
        var index = DivideArray(numbers, begin, end);
        QuickSort(numbers, begin, index - 1);
        QuickSort(numbers, index + 1, end);
    }
}

void BubbleSort(int[] numbers)
{
    bool changeInArray;
    do
    {
        changeInArray = false;

        for (int i = 0; i < (numbers.Length - 1); i++)
        {
            if (numbers[i + 1] < numbers[i])
            {
                ChangeElements(numbers, i, i + 1);
                changeInArray = true;
            }
        }
    } while (changeInArray);

}

void ChangeElements(int[] numbers, int index1, int index2)
{
    if (index1 != index2)
    {
        var temp = numbers[index1];
        numbers[index1] = numbers[index2];
        numbers[index2] = temp;
    }

}
int PointDivideArray(int begin, int end)
{
    return begin + ((end - begin) / 2);
}

int DivideArray(int[] numbers, int begin, int end)
{
    var divideIndex = PointDivideArray(begin, end);
    var valueDivideIndex = numbers[divideIndex];
    ChangeElements(numbers, divideIndex, end);
    var ActualIndex = begin;

    for (int i = begin; i < end; i++)
    {
        if (numbers[i] < valueDivideIndex)
        {
            ChangeElements(numbers, i, ActualIndex);
            ActualIndex++;
        }
    }
    ChangeElements(numbers, ActualIndex, end);
    return ActualIndex;
}

int[] DrawNumbersArray()
{
    int[] array = new int[150];
    Random randomNumber = new Random();
    for (int i = 0; i < array.Length; i++)
    {
        array[i] = randomNumber.Next(0, 1000);
    }
    return array;
}

void DisplayArray(int[] numbers)
{
    foreach (int i in numbers)
    {
        Console.Write($"{i:d3} ");
    }
    Console.WriteLine();

}


