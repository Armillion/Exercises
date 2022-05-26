import java.util.List;

public class test {

	
	public static void main(String[] args) {
		Kasjer a = new Kasjer();
		
		
		System.out.println(a.rozlicz(15,List.of(new Pieniadz(Nominal.Z£10, Rozmienialnosc.TAK),new Pieniadz(Nominal.Z£10, Rozmienialnosc.NIE))));
		
		
	}
}
