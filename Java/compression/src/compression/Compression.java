import java.util.ArrayList;
import java.util.Collections;
import java.util.HashMap;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;

public class Compression implements CompressionInterface{

	private ArrayList<String> words = new ArrayList<String>();
	private HashMap<String,String> compressedWords = new HashMap<String, String>();
	private ArrayList<String> allCompressedWords = new ArrayList<String>();
	
	private int wordsize = 0;
	private int nrWord;
	
	private String prevCompr = null;
	
	public Compression()
	{
		words.clear();
		compressedWords.clear();
		wordsize = 0;
		nrWord = 0;
	}
	
	public void addWord(String word) {
		// TODO Auto-generated method stub
		if(words.isEmpty())
		{
			words.add(word);
			wordsize = word.length();
		}
		else if(word.length() != wordsize)
		{
			
		}
		else
			words.add(word);
	}

	public List<String> mostPopularWord()
	{
		Map<String,Integer> map = new HashMap<String,Integer>();
		int nr = 0;
		
		for(String a : words)
		{
			for(String b : words)
			{
				if(a.equals(b))
				{
					nr++;
				}
			}
			map.put(a, nr);
			nr = 0;
		}
		
		ArrayList<String> resoult = new ArrayList<String>();
		int currNrOfBytes = 0;
		int max = 0;
		
		for( int i = map.size();  i > 0 ; i--)
		{
			Map.Entry<String, Integer> maxEntry = null;
			for (Map.Entry<String, Integer> entry : map.entrySet())
			{
			    if (maxEntry == null || entry.getValue().compareTo(maxEntry.getValue()) > 0)
			    {
			    	maxEntry = entry;
			    }
			}
			
			resoult.add(maxEntry.getKey());
			
			int estimatedNrOfBytes = 0;
			
			double i_double = (Math.log(resoult.size())/Math.log(2));
			int x = (int) Math.ceil(i_double);
			x++;
				
			for(String s : words)
			{
				if(resoult.contains(s))
				{
					estimatedNrOfBytes += x;
				}
				else
				{
					estimatedNrOfBytes += s.length() + 1;
				}
			}
			map.remove(maxEntry.getKey());
			
			int headerCount = (wordsize + x) * resoult.size();
			
			estimatedNrOfBytes += headerCount;
			
			if(estimatedNrOfBytes < currNrOfBytes || currNrOfBytes == 0)
			{
				max = resoult.size();
				currNrOfBytes = estimatedNrOfBytes;
			}
		}
		
		int test = 0;
		for(String a : words)
		{
			test += a.length();
		}
		
		if(test <= currNrOfBytes)
		{
			return null;
		}
		
		
		for(int i = 0 ; resoult.size() != max; i++)
		{
			resoult.remove(resoult.size() - 1);
		}
		return resoult;
	}
	
	public void compress() {

		compressedWords.clear();
		allCompressedWords.clear();
		
		List<String> word = new ArrayList<String>();
		
		if((word = mostPopularWord()) == null)
		{
			return;
		}
		
		double i_double = (Math.log(word.size())/Math.log(2));
		int i = (int) Math.ceil(i_double);
		i++;
		
		int j = 0;
		for(String a : words)
		{
			if(!word.contains(a))
			{
				allCompressedWords.add("1" + a);
			}
			else
			{
				String compr = "";
				compr += Integer.toBinaryString(j);
				
				for(int x = 0 ; compr.length() != i; x++)
				{
					compr = "0" + compr;				
				}	
				
				if(!compressedWords.containsKey(a))
				{
					compressedWords.put(a,compr);
					allCompressedWords.add(compr);
					j++;
				}
				else
				{
					allCompressedWords.add(compressedWords.get(a));
				}
			}
		}
		
	}

	public Map<String, String> getHeader() {
		
		Map<String, String> inv = new HashMap<String, String>();

	    for (Entry<String, String> entry : compressedWords.entrySet())
	        inv.put(entry.getValue(), entry.getKey());
		
		return inv;
	}

	public String getWord() {
		nrWord++;
		return allCompressedWords.get(nrWord - 1);
	}
}
