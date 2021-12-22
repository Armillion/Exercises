import java.util.ArrayList;
import java.util.List;

import org.w3c.dom.html.HTMLQuoteElement;
public class Loops implements GeneralLoops {

	private List<Integer> UpLims = new ArrayList<Integer>();
	private List<Integer> DownLims = new ArrayList<Integer>();
	private List<List<Integer>> output = new ArrayList<List<Integer>>();
	private int nrIterajcji = 0;
	
	@Override
	public void setLowerLimits(List<Integer> limits) {
		// TODO Auto-generated method stub
		DownLims.addAll(limits);
	}

	@Override
	public void setUpperLimits(List<Integer> limits) {
		// TODO Auto-generated method stub
		UpLims.addAll(limits);
	}

	@Override
	public List<List<Integer>> getResult() {
		if(UpLims.isEmpty() && DownLims.isEmpty())
			return List.of(List.of(0));
		if(DownLims.isEmpty())
		{
			for(Integer i : UpLims)
				DownLims.add(0);
		}
		if(UpLims.isEmpty())
		{
			for(Integer i : DownLims)
				UpLims.add(0);
		}
		
		output.clear();
		output.add(new ArrayList<Integer>());
		output.get(0).addAll(DownLims);
		
		this.looping(0);
		output.remove(output.size() - 1);
		
		DownLims.clear();
		UpLims.clear();
		nrIterajcji = 0;
		
		return output;
	}
	
	private void looping(int n) {
		if(n >= DownLims.size())
			return;
		for(int i = DownLims.get(n); i <= UpLims.get(n); i++)
		{
			output.get(nrIterajcji).set(n,i);
			this.looping(n+1);
			if(n == DownLims.size() - 1)
			{
				nrIterajcji++;
				output.add(new ArrayList<Integer>());
				output.get(nrIterajcji).addAll(output.get(nrIterajcji-1));
			}
		}
	}
	
	
	
}
