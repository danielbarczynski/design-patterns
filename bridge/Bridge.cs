using System;

//pozmieniałem troszkę kod for fun, naprawdę przyjemny wzorzec ^^

public interface ITelewizor
{
	int Kanal { get; set; }
	void ZmienKanal(int kanal);
}

public class TvLg : ITelewizor
{

	public TvLg()
	{
		Kanal = 666;
	}

	public int Kanal { get; set; }

	public void Wlacz()
	{
		Console.WriteLine("Telewizor LG włączony.");
	}

	public void Wylacz()
	{
		Console.WriteLine("Telewizor LG wyłączony.");
	}

	public void ZmienKanal(int kanal)
	{
		Console.WriteLine("Telewizor LG kanał: " + kanal);
	}

}

public class TvPhillips : ITelewizor
{
	public int Kanal { get; set; }

	public TvPhillips() // konstuktor z wartością default
	{
		Kanal = 21;
	}
	public void Wlacz()
	{
		Console.WriteLine("Telewizor Phillips włączony.");
	}

	public void Wylacz()
	{
		Console.WriteLine("Telewizor Phillips wyłączony.");
	}

	public void ZmienKanal(int kanal)
	{
		Console.WriteLine("Telewizor Phillips kanał: " + kanal);
	}
}

public abstract class PilotAbstrakcyjny
{

	//private ITelewizor tv;

	//public PilotAbstrakcyjny(ITelewizor tv)
	//{
	//	this.tv = tv;
	//}

	//public void ZmienKanal(int kanal)
	//{
	//	//tv.ZmienKanal(kanal);
	//	ZmienKanal(kanal);

	//}
	public abstract void ZmienKanal(int kanal);
	public abstract void DoWlacz();
	public abstract void DoWylacz();

}

public class PilotHarmony : PilotAbstrakcyjny
{

	public PilotHarmony(ITelewizor tv) //: base(tv) 
	{

	}

	public override void DoWlacz()
	{
		Console.WriteLine("Pilot Harmony włącza telewizor...");
	}

	public override void DoWylacz()
	{
		Console.WriteLine("Pilot Harmony wyłącza telewizor...");
	}
	public override void ZmienKanal(int kanal)
	{
		Console.WriteLine("Pilot Harmony zmienia kanał na: " + kanal);
	}
}
public class PilotPhillips : PilotAbstrakcyjny
{

	public PilotPhillips(ITelewizor tv) //: base(tv) 
	{

	}

	public override void DoWlacz()
	{
		Console.WriteLine("Pilot Phillips włącza telewizor...");
	}

	public override void DoWylacz()
	{
		Console.WriteLine("Pilot Phillips wyłącza telewizor...");
	}
	public override void ZmienKanal(int kanal)
	{
		Console.WriteLine("Pilot Phillips zmienia kanał na: " + kanal);
	}
}

class Program
{
	public static void Main(string[] args)
	{

		TvLg tvLg = new TvLg();
		PilotAbstrakcyjny pilotHarmony = new PilotHarmony(tvLg);

		TvPhillips tvPhillips = new TvPhillips();
		PilotPhillips pilotPhillips = new PilotPhillips(tvPhillips);
		//tv.Kanal = 100;

		//nie wiem czy o to chodziło, ale ważne że działa, haha
		pilotHarmony.DoWlacz();
		tvLg.Wlacz();
		Console.WriteLine("Telewizor LG kanał: " + tvLg.Kanal);
		pilotHarmony.ZmienKanal(999);
		tvLg.ZmienKanal(999);
		pilotHarmony.DoWylacz();
		tvLg.Wylacz();

		Console.WriteLine();

		pilotPhillips.DoWlacz();
		tvPhillips.Wlacz();
		Console.WriteLine("Telewizor Phillips kanał: " + tvPhillips.Kanal);
		pilotPhillips.ZmienKanal(37);
		tvPhillips.ZmienKanal(37);
		pilotPhillips.DoWylacz();
		tvPhillips.Wylacz();

	}
}