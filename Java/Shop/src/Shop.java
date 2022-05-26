import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;
import java.util.Map.Entry;

public class Shop implements ShopInterface {
	
	private Map<String , Integer> magazine = new HashMap<String , Integer>();
	private HashMap<String,Object> clients = new HashMap<String, Object>();
	
	public void delivery(Map<String, Integer> goods) {
		for(Entry<String, Integer> product : goods.entrySet())
		{
			synchronized (getClient(product.getKey())) 
			{
				if(magazine.containsKey(product.getKey()))
				{
					magazine.put(product.getKey(), magazine.get(product.getKey()) + product.getValue());
					clients.get(product.getKey()).notifyAll();
				}
				else
				{
					magazine.put(product.getKey(), product.getValue());
					clients.get(product.getKey()).notifyAll();
				}
			}
		}
	}

	public boolean purchase(String productName, int quantity) {
		synchronized (getClient(productName)) 
		{
			if(magazine.containsKey(productName))
			{
				if(magazine.get(productName) >= quantity)
				{
					magazine.put(productName, magazine.get(productName) - quantity);
					return true;
				}
				else
				{
					try {
						clients.get(productName).wait();
						
					} catch (InterruptedException e) {
						e.printStackTrace();
					}
					
					if(magazine.get(productName) >= quantity)
					{
						magazine.put(productName, magazine.get(productName) - quantity);
						return true;
					}
					return false;
				}
			}
			else
			{
				try {
					clients.get(productName).wait();
					if(magazine.get(productName) >= quantity)
					{
						magazine.put(productName, magazine.get(productName) - quantity);
						return true;
					}
				} catch (InterruptedException e) {
					e.printStackTrace();
				}
				return false;
			}
		}
	}
	
	private Object getClient(String name)
	{
		if(clients.containsKey(name))
		{
			return clients.get(name);
		}
		
		clients.put(name, new Object());
		
		return clients.get(name);
	}

	public Map<String, Integer> stock() {
		return magazine;
	}
}