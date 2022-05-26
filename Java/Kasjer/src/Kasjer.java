import java.util.ArrayList;
import java.util.Collections;
import java.util.List;
import java.util.function.Supplier;

public class Kasjer implements KasjerInterface{

	private List<Pieniadz> kasa = new ArrayList<>();
	private RozmieniaczInterface rozmieniacz;
	//private List<Pieniadz> wynik = new ArrayList<Pieniadz>();
	
	@Override
	public List<Pieniadz> rozlicz(int cena, List<Pieniadz> pieniadze) {
		// TODO Auto-generated method stub
		ArrayList<Pieniadz> hajs = new ArrayList<Pieniadz>(pieniadze);
		
		Collections.sort(hajs, (p1, p2) -> p1.wartosc() - p2.wartosc());
        Collections.reverse(hajs);
		kasa.addAll(hajs);
		
		int suma = 0;
		for(Pieniadz a : pieniadze)
		{
			suma += a.wartosc();
		}
		if(suma - cena == 0)
		{
			return new ArrayList<Pieniadz>();
		}
		
		int wSumieRozmienialnych = 0;
		ArrayList<Pieniadz> resoult = new ArrayList<Pieniadz>();
		
		for(int i = (hajs.size() - 1); i >= 0;i-- )
		{
			if(!hajs.get(i).czyMozeBycRozmieniony())
			{
				wSumieRozmienialnych += hajs.get(i).wartosc();
				if(wSumieRozmienialnych == cena)
				{
					return resoult;
				}
				else if(wSumieRozmienialnych > cena)
				{
					wSumieRozmienialnych -= hajs.get(i).wartosc();
					break;
				}
				hajs.remove(hajs.get(i));
			}
		}
		
		for(Pieniadz p : hajs)
		{
			if(p.czyMozeBycRozmieniony())
			{
				wSumieRozmienialnych += p.wartosc();
				if(wSumieRozmienialnych == cena)
				{
					return resoult;
				}
				else if(wSumieRozmienialnych > cena)
				{
					wSumieRozmienialnych -= p.wartosc();
					resoult.addAll(helpFunc(wSumieRozmienialnych + p.wartosc() - cena));
					for(Pieniadz reszta : resoult)
					{
						if(kasa.contains(reszta))
						{
							kasa.remove(reszta);						
						}
					}
					return resoult;
				}
			}
		}
		
		for(Pieniadz p : hajs)
		{
			if(!p.czyMozeBycRozmieniony())
			{
				wSumieRozmienialnych += p.wartosc();
				resoult.add(p);
				int rest = wSumieRozmienialnych - cena;
				
				resoult.addAll(helpFunc(rest));
				for(Pieniadz reszta : resoult)
				{
					if(kasa.contains(reszta))
					{
						kasa.remove(reszta);						
					}
				}
			
				return resoult;
			}
		}
		
		return resoult;
	}
	
	private List<Pieniadz> helpFunc(int cena)
	{
		int kop = cena;
		ArrayList<Pieniadz> resout = new ArrayList<Pieniadz>();
		for(Pieniadz p : kasa)
		{
			if(p.czyMozeBycRozmieniony())
			{
				if(p.wartosc() <= cena)
				{
					resout.add(p);
					cena -= p.wartosc();
				}
				if(cena == 0)
				{
					break;
				}
			}
		}
		
		if(cena > 0)
		{
			Collections.sort(kasa, (p1, p2) -> p1.wartosc() - p2.wartosc());
			Collections.reverse(kasa);
			
			int c = 0;
			for(Pieniadz e : kasa)
			{
				if(e.czyMozeBycRozmieniony())
				{
					break;
				}
				c++;
			}
			List <Pieniadz> rozmienione = rozmieniacz.rozmien(kasa.get(c));
			kasa.remove(c);

			for(Pieniadz i : rozmienione)
			{
				kasa.add(i);
			}
			
			resout.clear();
		}
		
		if(resout.isEmpty())
			return helpFunc(kop);
		else
		{	
			//throw new RuntimeException(resout.toString());
			return resout;
		}
	}

	@Override
	public List<Pieniadz> stanKasy() {
		// TODO Auto-generated method stub
		return kasa;
	}

	@Override
	public void dostępDoRozmieniacza(RozmieniaczInterface rozmieniacz) {
		// TODO Auto-generated method stub
		this.rozmieniacz = rozmieniacz;
	}

	@Override
	public void dostępDoPoczątkowegoStanuKasy(Supplier<Pieniadz> dostawca) {
		// TODO Auto-generated method stub
			Pieniadz a = dostawca.get();
			while(a != null)
			{
				kasa.add(a);
				a = dostawca.get();
			}
	}
}
