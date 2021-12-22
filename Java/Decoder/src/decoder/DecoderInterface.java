package decoder;

public abstract class DecoderInterface {
	
	public abstract void input(int bit);

	
	public abstract String output();

	
	public abstract void reset();
}
