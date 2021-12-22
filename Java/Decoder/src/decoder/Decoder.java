class Decoder extends DecoderInterface{
	
	private int count;				//zmienna przechowujaca ilosc bitow przed pojawieniem sie 0
	private String resoult;			//wynik po zdekodowaniu podanego ciagu
	private int helper;				//pomocnik przechowujacy ilosc jedynek skladajacych sie na X
	
	public void input(int bit)			//wprowadzanie danych bit po bicie
	{
		switch(bit) 					
		{
		case 1:							//jeśli mamy 1 to dodajemy do ich licznika
			count++;
			break;
		case 0:							//jesli zero to mozemy zdekodowac to co znalazlo sie za nim
			this.decode();
			break;
		}
	}
	
	private void decode()				//dekodowanie ciągu jedynek zakonczonego 0, innymi slowy 1 znaku
	{	
		if(count == 0)					//jesli przed 0 nie pojawila sie ani 1 jedynka nie robimy nic
			return;
		
		if(helper == 0)					//jesli nie podalismy liczby pomocnikowi, oznacza to że jest to 1 znak - zakodowane 0
		{
			helper = count;				//podajemy pomocnikowi ile 1 zakodowalo 0
			count = 0;					//zerujemy licznik jedynek
			resoult = "0";				//i dodajemy 0 do wyniku koncowego
			return;
		}
		else
		{
			switch(count/helper)		//jesli podalismy juz pomocnikowi liczbe 1 skladajacych sie na X, mozemy uzyc tej wiadomosci do
			{							//zdekodowania ruznych ilosci X na adekwatne znaki i dodac je do wyniku
			case 1:
				resoult += "0";
				count = 0;
				break;
			case 2:
				resoult += "1";
				count = 0;
				break;
			case 3:
				resoult += "2";
				count = 0;
				break;
			case 4:
				resoult += "4";
				count = 0;
				break;
			}
		}
	}
	
	public String output()				//pole resoult jest prywatne, więc do dostania się do jego wartości posłuży nam funkcja output
	{
		return resoult;
	}
	
	public void reset()					//resetowanie naszych 3 zmiennych
	{
		count = 0;
		helper = 0;
		resoult = "";
	}
	
	public static void main(String[] args) 								//zdecydowałem sie napisac metode main wykozystujaca wszystkie
	{																	//powyrzsze metody
		DecoderInterface obj = new Decoder();							//objekt wywolujacy dane metody
		for(int i = 0; i < args[0].length(); i++)
		{
			obj.input(Character.getNumericValue(args[0].charAt(i)));	//czytamy kod przekazany w 1 argumencie znak za znakiem
		}
		System.out.print(obj.output());									//wypisujemy wynik
		obj.reset();													//i resetujemy
	}
}
