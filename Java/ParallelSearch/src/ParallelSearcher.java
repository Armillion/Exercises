

public class ParallelSearcher implements ParallelSearcherInterface {

	public class ThreadSearch extends Thread
	{
		private HidingPlaceSupplier supp;
		
		public ThreadSearch(HidingPlaceSupplier a)
		{
			this.supp = a;
		}
		
		public void run()
		{
			HidingPlaceSupplier.HidingPlace HP;
			synchronized (ParallelSearcher.this) {
				HP = supp.get();				
			}
			
			if(HP == null)
			{
				return;
			}
			
			if(!HP.isPresent())
			{
				
			}
			else
			{
				synchronized (ParallelSearcher.this) {
					currSum += HP.openAndGetValue();
				}
			}
			
			run();
		}
	}
	
	
	double currSum = 0;
	
	@Override
	public void set(HidingPlaceSupplierSupplier supplier) {
		// TODO Auto-generated method stub
		HidingPlaceSupplier HPSupp = supplier.get(currSum);
		currSum = 0;
		if(HPSupp == null)
		{
			return;
		}
		
		int nrOfHP = HPSupp.threads();
		ThreadSearch[] threads = new ThreadSearch[nrOfHP];
		for(int i = 0 ; i < nrOfHP ; i++)
		{
			threads[i] = new ThreadSearch(HPSupp);
			threads[i].start();
		}
		
		for(ThreadSearch t : threads)
		{
			try {
				t.join();
			} catch (InterruptedException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
		}
		
		this.set(supplier);
	}

}
