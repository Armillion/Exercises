import java.util.ArrayList;
import java.util.HashMap;
import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.Set;
import java.util.stream.Collectors;

public class Decrypter implements DecrypterInterface {
	
	private String document = "";
	Map<Character,Character> resoult = new HashMap<Character,Character>();
	
	@Override
	public void setInputText(String encryptedDocument) {
		// TODO Auto-generated method stub
		document = encryptedDocument;
		resoult.clear();
		if(document == null)
			document = " ";
		getResoult();
	}

	private void getResoult()
	{
		String[] tekst = {"Wydział","Fizyki,","Astronomii","i","Informatyki","Stosowanej"};
		String[] toCompare = document.split("\\s+");
		
		List<Integer> pom = new ArrayList<Integer>();
		for(int i = 0; i < toCompare.length; i++)
		{
			if(toCompare[i].length() == tekst[1].length() && toCompare[i].charAt(6) == ',')
			{
				pom.add(i);
			}
		}
		if(pom.isEmpty())
			return;
		
		for(Integer b : pom)
		{
			resoult.clear();
			for(int i = b - 1 , a = 0; i < b + tekst.length - 1 && a < tekst.length; i++,a++)
			{
				if(toCompare[i].length() == tekst[a].length())
				{
					System.out.println(tekst[a]);
					for(int j = 0; j < toCompare[i].length(); j++)
					{
						if(resoult.containsKey(tekst[a].charAt(j)) && (resoult.get(tekst[a].charAt(j)) != toCompare[i].charAt(j)))
						{
							resoult.clear();
							break;
						}
						resoult.put(tekst[a].charAt(j), toCompare[i].charAt(j));
					}
				}
			}
			resoult.remove(',');
			if(resoult.size() == 22 && !(resoult.containsValue(',')))
			{
				return;
			}
		}
		
		resoult.clear();	
	}
	
	@Override
	public Map<Character, Character> getCode() {
		// TODO Auto-generated method stub
		return resoult;
	}

	@Override
	public Map<Character, Character> getDecode() {
		// TODO Auto-generated method stub
		Map<Character,Character> tmp = resoult.entrySet().stream().collect(Collectors.toMap(Map.Entry::getValue, Map.Entry::getKey));
		return tmp;
	}

}
