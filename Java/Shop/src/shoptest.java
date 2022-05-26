import java.util.HashMap;

public class shoptest {

	public static void main(String[] args) {
		Shop a = new Shop();
		
		HashMap<String, Integer> b = new HashMap<String, Integer>();
		b.put("owoce", 2);
		b.put("ryba", 4);
		
		a.delivery(b);
		
		System.out.println(a.stock());
		
		b.remove("ryba");
		b.put("owoce", 5);
		b.put("pizza", 1);
		
		a.delivery(b);
		
		System.out.println(a.stock());
	}
	
}
