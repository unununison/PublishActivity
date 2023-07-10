// See https://aka.ms/new-console-template for more information
using PublishActivity.API.Services;
using System.Diagnostics;

Console.WriteLine("Hello, World!");

var service = new ImpactFactorService();

var watch = new Stopwatch();

watch.Start();
for (int i = 0; i < 10; i++)
{
	var k = await service.FindAsync("02683768"); 
}
watch.Stop();

Console.WriteLine("Newest FindAsyncc time: {0} ms", watch.ElapsedMilliseconds);

watch.Restart();
watch.Start();
for (int i = 0; i < 10; i++)
{
	var k = await service.FindAsyncOld("02683768");
}
watch.Stop();

Console.WriteLine("Oldest FindAsyncc time: {0} ms", watch.ElapsedMilliseconds);

var t = 0;