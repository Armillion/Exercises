import java.io.Serializable;

public class SerializableClass implements Serializable {
	private static final long serialVersionUID = -953483399088817898L;
	private final int code;

	public SerializableClass(int code) {
		this.code = code;
	}

	public int getCode() {
		return code;
	}
}