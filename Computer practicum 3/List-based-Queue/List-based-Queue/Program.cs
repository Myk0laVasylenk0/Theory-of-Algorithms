using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;

class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string SurName { get; set; }
    public string[] TeoryQues { get; set; }
    public string[] PractTasks { get; set; }
    public Student()
    {
        TeoryQues = new string[3];
        PractTasks = new string[2];
    }

}

public class LinkedListQueue<T>
{
    private class Node
    {
        public T Value { get; set; }
        public Node Next { get; set; }

        public Node(T value)
        {
            Value = value;
            Next = null;
        }
    }

    private Node head = null;
    private Node tail = null;
    private int count = 0;

    public void ListEnqueue(T element)
    {
        Node newNode = new Node(element);
        if (tail == null)
        {
            head = tail = newNode;
        }
        else
        {
            tail.Next = newNode;
            tail = newNode;
        }
        count++;
    }

    public T ListDequeue()
    {
        if (count == 0)
            throw new Exception("Queue is empty");

        T value = head.Value;
        head = head.Next;
        if (head == null)
        {
            tail = null;
        }
        count--;
        return value;
    }

    public int Count
    {
        get { return count; }
    }
}

class ExamProcess
{

    public void TeoryAndPrak(LinkedListQueue<Student> studentsQueue)
    {
        //Список з усіма питаннями по 3 питання на кожного студента
        Queue<string> question = new Queue<string>();

        question.Enqueue("1. З яких етапiв складається процес створення комп’ютерної програми для вирiшення довiльної практичної задачi?");
        question.Enqueue("2. Що саме має з’ясувати розробник програми на етапi постановки задачі?");
        question.Enqueue("3. Що робить розробник програми на етапi побудови моделi? Якi фактори впливають на вибiр структури моделi?");
        question.Enqueue("4. Якими мiркуваннями має керуватися розробник програми на етапi розробки алгоритму?");
        question.Enqueue("5. Навiщо виконується аналiз алгоритму та його складностi?");
        question.Enqueue("6. Iснує три аспекти перевiрки програми: на правильнiсть, на ефективнiсть реалiзацii, на обчислювальну складнiсть. Розкрийте суть кожноi з перевiрок.");
        question.Enqueue("7. Навiщо виконується вимiрювання часу виконання програми? Якi чинники на нього впливають?");
        question.Enqueue("8. Пояснiть рiзницю мiж термiнами «тип даних», «абстрактний тип даних» «структура даних».");
        question.Enqueue("9. Проаналiзуйте АТД «зв’язний лiнiйний список»; перерахуйте, якi рiзновиди спискiв бувають.");
        question.Enqueue("10. Проаналiзуйте АТД «стек»; перерахуйте, якi операцii можна виконувати з цим АТД.");
        question.Enqueue("11. Перерахуйте послiдовнiсть дiй при вставцi елемента до стеку.");
        question.Enqueue("12. Перерахуйте послiдовнiсть дiй при видаленнi елемента зi стеку.");
        question.Enqueue("13. Проаналiзуйте АТД «черга»; перерахуйте, якi операцii можна виконувати з цим АТД.");
        question.Enqueue("14. Перерахуйте послiдовнiсть дiй при вставцi елемента до черги.");
        question.Enqueue("15. Проаналiзуйте АТД «однозв’язний лiнiйний список».");
        question.Enqueue("16. Перерахуйте послiдовнiсть дiй при вставцi елемента в середину списку.");
        question.Enqueue("17. Перерахуйте послiдовнiсть дiй при видаленнi елемента з середини списку.");
        question.Enqueue("18. Перерахуйте послiдовнiсть дiй при видаленнi елемента з кiнця списку.");


        Queue<string> task = new Queue<string>();

        task.Enqueue("1. Напишiть програму, що обчислює суму двох чисел, введених користувачем з клавiатури.");
        task.Enqueue("2. Створiть клас для представлення прямокутника з методами обчислення площi та периметра.");
        task.Enqueue("3. Розробiть програму для сортування масиву цiлих чисел за зростанням.");
        task.Enqueue("4. Напишiть програму, яка виводить всi простi числа в заданому дiапазонi.");
        task.Enqueue("5. Створiть клас для роботи зi студентами, який мiстить властивостi для iмен, прiзвища та середнього балу. Додайте метод для обчислення середнього балу всiх студентiв у групi.");
        task.Enqueue("6. Реалiзуйте алгоритм бiнарного пошуку для пошуку елемента в вiдсортованому масивi.");
        task.Enqueue("7. Напишiть програму, яка перевiряє, чи є введений рядок палiндромом.");
        task.Enqueue("8. Створiть клас для роботи з матрицями (додавання, множення, транспонування тощо).");
        task.Enqueue("9. Розробiть програму, яка обчислює факторiал числа, введеного користувачем.");
        task.Enqueue("10. Напишiть програму для перевiрки чи є задане число простим.");
        task.Enqueue("11. Створiть програму для переведення рядка в верхнiй i нижнiй регiстр.");
        task.Enqueue("12. Реалiзуйте алгоритм сортування бульбашкою для сортування масиву цiлих чисел.");


        Student currentStudent = studentsQueue.ListDequeue();


        for (int i = 0; i <= 2; i++)
        {
            currentStudent.TeoryQues[i] = question.Dequeue();
            question.Enqueue(currentStudent.TeoryQues[i]);
        }

        for (int i = 0; i <= 1; i++)
        {
            currentStudent.PractTasks[i] = task.Dequeue();
            task.Enqueue(currentStudent.PractTasks[i]);

        }

        while (studentsQueue.Count > 0)
        {   //якщо в черзі є студенти то частина завдання поточного студента передається наступному
            if (studentsQueue.Count > 0)
            {
                Student nextStudent = studentsQueue.ListDequeue();

                nextStudent.TeoryQues[0] = currentStudent.TeoryQues[2];
                nextStudent.PractTasks[0] = currentStudent.PractTasks[1];

                currentStudent = nextStudent;
            }

            ConductTheoryExam(currentStudent, question);
            ConductPracticalExam(currentStudent, task);

        }
    }

    private void ConductTheoryExam(Student student, Queue<string> question)
    {

        student.TeoryQues[1] = question.Dequeue();
        question.Enqueue(student.TeoryQues[1]);

        student.TeoryQues[2] = question.Dequeue();
        question.Enqueue(student.TeoryQues[2]);
    }

    private void ConductPracticalExam(Student student, Queue<string> task)
    {
        student.PractTasks[1] = task.Dequeue();
        task.Enqueue(student.PractTasks[1]);
    }

}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("List-based Queue" + "\n");

        var watch = System.Diagnostics.Stopwatch.StartNew();

        List<Student> students = new List<Student>
        {
new Student { Id = 1, Name = "Анна", SurName = "Петрова" },
new Student { Id = 2, Name = "Іван", SurName = "Коваленко" },
new Student { Id = 3, Name = "Олександра", SurName = "Мельник" },
new Student { Id = 4, Name = "Максим", SurName = "Ковальчук" },
new Student { Id = 5, Name = "Софія", SurName = "Шевченко" },
new Student { Id = 6, Name = "Михайло", SurName = "Лисенко" },
new Student { Id = 7, Name = "Вікторія", SurName = "Бондаренко" },
new Student { Id = 8, Name = "Артем", SurName = "Павленко" },
new Student { Id = 9, Name = "Вероніка", SurName = "Коваленко" },
new Student { Id = 10, Name = "Олег", SurName = "Григоренко" },


        };



        LinkedListQueue<Student> studentQuene = new LinkedListQueue<Student>();

        ExamProcess examProcess = new ExamProcess();

        // Start exam process
        foreach (Student student in students)
        {
            studentQuene.ListEnqueue(student);
        }
        examProcess.TeoryAndPrak(studentQuene);

        Console.WriteLine();
        Console.WriteLine("Теорiя");
        Console.WriteLine();

        foreach (Student student in students)
        {
            Console.WriteLine(student.Name + " " + student.SurName + "  ID-" + student.Id);

            Console.WriteLine();

            foreach (string TeorQues in student.TeoryQues)
            {
                Console.WriteLine(TeorQues);
            }

            Console.WriteLine();
        }

        Console.WriteLine();
        Console.WriteLine("Практика");
        Console.WriteLine();

        foreach (Student student in students)
        {
            Console.WriteLine(student.Name + " " + student.SurName + "  ID-" + student.Id);

            Console.WriteLine();
            foreach (string PrakTask in student.PractTasks)
            {
                Console.WriteLine(PrakTask);
            }
            Console.WriteLine();

        }

        watch.Stop();

        Console.WriteLine("List-based Queue" + "\n");
        Console.WriteLine($"Elements count: {students.Count}");
        Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");

        Console.ReadLine();
    }
}