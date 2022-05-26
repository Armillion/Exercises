import java.io.*;
import java.net.*;
import java.util.ArrayList;



public class PasswordCracker implements PasswordCrackerInterface {

    private Socket clientSocket;
    private PrintWriter out;
    private BufferedReader in;
    private ArrayList<Integer> chars = new ArrayList<Integer>();
    
	@Override
	public String getPassword(String host, int port) {
		String a;
		String schema = "";
		String haslo = "";
		String prevHaslo = "";
		int correctChars = 0;
		int prevCorrentChars = 0;
		int i = -1;
		boolean zmiana = true;
		chars.clear();

		try {
			clientSocket = new Socket(host,port);
		out = new PrintWriter(clientSocket.getOutputStream());
		in = new BufferedReader(new InputStreamReader(clientSocket.getInputStream()));
		
		while((a = in.readLine()) != null)
		{
			if ("+OK".equals(a))
			{
				break;
			}
			
			if(a.equals("Wersja 1.0. Powitać! Z kim rozmawiam: Człowiek czy Program? 20 sekund na odpowiedz"))
			{
				out.println("Program");
				out.flush();
			}
			else if(a.contains("schema"))
			{
				schema = a.substring(9);
				schema = schema.replaceAll(" ", "");
			}
			else if(a.contains("hasło") && a.contains("Zgadnij"))
			{
				for(int j = 0; j < schema.length() ; j++)
				{
					switch(schema.charAt(j))
					{
						case 'l':
						haslo += PasswordComponents.lowercaseLetters.get(0);
						chars.add(0);
						break;
						case 'u':
						haslo += PasswordComponents.uppercaseLetters.get(0);
						chars.add(0);
						break;
						case 'n':
						haslo += PasswordComponents.numbers.get(0);
						chars.add(0);
						break;
						case 's':
						haslo += PasswordComponents.symbols.get(0);
						chars.add(0);
						break;
					}
				}
				
				prevHaslo = haslo;
				out.println(haslo);
				out.flush();
			}
			else if(a.contains("hasło"))
			{
				StringBuilder bobBudowniczy = new StringBuilder(haslo);
				correctChars = Integer.parseInt(a.substring(25,26));
				if(correctChars > prevCorrentChars)
				{
					i++;
					zmiana = true;
				}
				else if(correctChars < prevCorrentChars)
				{
					haslo = prevHaslo;
					zmiana = true;
					prevHaslo = haslo;
				}
				else
				{
					prevHaslo = haslo;
				}
				
				if (!zmiana){
					switch(schema.charAt(i))
					{
						case 'l':
						if(haslo.charAt(i)=='z')
						{
							chars.set(i, 0);
							bobBudowniczy.setCharAt(i, PasswordComponents.lowercaseLetters.get(chars.get(i)));
						}
						else
						{
							chars.set(i, chars.get(i) + 1);
							bobBudowniczy.setCharAt(i, PasswordComponents.lowercaseLetters.get(chars.get(i)));;
						}
						break;
						case 'u':
						if(haslo.charAt(i)=='Z')
						{
							chars.set(i, 0);
							bobBudowniczy.setCharAt(i, PasswordComponents.uppercaseLetters.get(chars.get(i)));
						}
						else
						{
							chars.set(i, chars.get(i) + 1);
							bobBudowniczy.setCharAt(i, PasswordComponents.uppercaseLetters.get(chars.get(i)));
						}
						break;
						case 'n':
						if(haslo.charAt(i)=='9')
						{
							chars.set(i, 0);
							bobBudowniczy.setCharAt(i, PasswordComponents.numbers.get(chars.get(i)));
						}
						else
						{
							chars.set(i, chars.get(i) + 1);
							bobBudowniczy.setCharAt(i, PasswordComponents.numbers.get(chars.get(i)));
						}
						break;
						case 's':
						if(haslo.charAt(i)=='_')
						{
							chars.set(i, 0);
							bobBudowniczy.setCharAt(i, PasswordComponents.symbols.get(chars.get(i)));
						}
						else
						{
							chars.set(i, chars.get(i) + 1);
							bobBudowniczy.setCharAt(i, PasswordComponents.symbols.get(chars.get(i)));
						}
						break;
					}
				}

				if (i == -1)
				{
					i++;
				}

				if (!zmiana)
				{
					haslo = bobBudowniczy.toString();
				}
				
				prevCorrentChars = correctChars;
				zmiana = false;
				
				out.println(haslo);
				out.flush();
				
			}
			//System.out.println("Haslo: " + haslo + " Schemat: " + schema + " Poprawnych: " + correctChars);
		}
		
		in.close();
		out.close();
		clientSocket.close();
		} catch (UnknownHostException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		return haslo;
	}

}
