
foreach (var i in new PrimeEnumerator(30))
{
    Console.WriteLine(i);
    if (i > 50)
    {
        break;
    }
}
