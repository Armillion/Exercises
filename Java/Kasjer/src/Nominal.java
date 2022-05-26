
public enum Nominal {
	ZŁ1(1), ZŁ2(2), ZŁ5(5), ZŁ10(10), ZŁ20(20), ZŁ50(50), ZŁ100(100), ZŁ200(200), ZŁ500(500);
	
	private int wartoĹÄ;
	
	private Nominal( int wartoĹÄ ) {
		this.wartoĹÄ = wartoĹÄ;
	}
	
	public int wartoĹÄ() {
		return wartoĹÄ;
	}
}