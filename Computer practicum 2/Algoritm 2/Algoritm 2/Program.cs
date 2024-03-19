int place_count = 12;

Dictionary<int, string> plases = new()
{
    [0] = "Гуртожиток",
    [1] = "Червоний корпус КНУ",
    [2] = "Андрiївська церква",
    [3] = "Михайлiвський золотоверхий",
    [4] = "Золотi ворота",
    [5] = "Лядськi ворота",
    [6] = "Фунiкулер",
    [7] = "КПI",
    [8] = "Фонтан на Хрещатику",
    [9] = "Софiївський собор",
    [10] = "Нацiональна фiлармонiя",
    [11] = "Музей однiєї вулицi"
};

List<Edge> E = new List<Edge>();
E.Add(new Edge(0, 7, 1200));
E.Add(new Edge(7, 4, 4700));
E.Add(new Edge(4, 9, 1300));
E.Add(new Edge(4, 1, 900));
E.Add(new Edge(1, 8, 950));
E.Add(new Edge(8, 5, 1100));
E.Add(new Edge(1, 5, 1600));
E.Add(new Edge(5, 9, 650));
E.Add(new Edge(11, 5, 1700));
E.Add(new Edge(2, 11, 600));
E.Add(new Edge(2, 5, 1000));
E.Add(new Edge(5, 3, 500));
E.Add(new Edge(3, 2, 600));
E.Add(new Edge(10, 5, 950));
E.Add(new Edge(6, 10, 750));
E.Add(new Edge(2, 6, 600));

List<Edge> AlgPr = new List<Edge>();
algorithmByPrim(12, E, AlgPr);

for (int i = 0; i < AlgPr.Count; i++)
{
    Console.WriteLine(plases[AlgPr[i].v1] + " -> " + plases[AlgPr[i].v2] + " = " + AlgPr[i].weight + " метрiв");
}

Console.ReadKey();
void algorithmByPrim(int numberV, List<Edge> E, List<Edge> MST)
{
    List<Edge> sortedE = E.OrderBy(e => e.weight).ToList();    //відсортовані ребра

    List<int> usedV = new List<int>();    //використані вершини

    List<int> notUsedV = new List<int>();    //невикористані вершини

    for (int i = 0; i < numberV; i++)    //заповнюю невикористані вершини

    {
        notUsedV.Add(i);
    }

    usedV.Add(0);    //додаю вершину старту
    notUsedV.RemoveAt(usedV[0]);

    while (notUsedV.Count > 0) // цикл продовжується поки всі вершини не опиняться в дереві
    {
        bool find = false; //змінна яка показуватиме чи знайшлося потрібне ребро
        for (int i = 0; i < sortedE.Count; i++)//пошук ребрв
        {
            if (usedV.IndexOf(sortedE[i].v1) != -1)//випадок коли запис в вигляду (v1,v2) і ми знаходимось в вершині v1
            {
                if (notUsedV.IndexOf(sortedE[i].v2) != -1)//перевірка чи v2 невідвідана
                {
                    usedV.Add(sortedE[i].v2);//додаємо до списку використаних вершин(тих які ми відвідали) і видаляємо з невикористаних
                    notUsedV.Remove(sortedE[i].v2);
                    find = true;
                }
            }
            else if (usedV.IndexOf(sortedE[i].v2) != -1)//випадок коли запис в вигляду (v1,v2) і ми знаходимось в вершині v2
            {
                if (notUsedV.IndexOf(sortedE[i].v1) != -1)//перевірка чи v1 невідвідана
                {
                    usedV.Add(sortedE[i].v1);//додаємо до списку використаних вершин(тих які ми відвідали) і видаляємо з невикористаних
                    notUsedV.Remove(sortedE[i].v1);
                    find = true;
                }
            }
            if (find == true)//якщо ми знайшли потрібне ребро, то додаємо його в дерево і видаляємо з списку ребер
            {
                MST.Add(sortedE[i]);
                sortedE.RemoveAt(i);
                break;//вихід з циклу оскільки розмір sortedE змінився
            }
        }
    }
}
public class Edge //клас що зберігатиме інформацію про ребро
{
    public int v1, v2;

    public int weight;

    public Edge(int v11, int v22, int weightt)
    {
        v1 = v11;
        v2 = v22;
        weight = weightt;
    }
}
