import java.io.FileNotFoundException;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.Properties;

import javax.xml.ws.Endpoint;

public class Server {

	public static void main(String[] args) {
		Properties prop = null;
		if(args.length > 0) {
			prop = ConfReader.getConf(args[0]);
		} else {
			prop = ConfReader.getConf();
		}
		Endpoint.publish("http://localhost:" + prop.getProperty("port") + "/messageRequest",
				new MessageRequestWebServiceImpl(prop.getProperty("endpoint"),
						prop.getProperty("SOAPAction"),
						readFile(prop.getProperty("XMLFilePath"))));
	}

	
	private static String readFile(String filePath) {
		try {
			return new String(Files.readAllBytes(Paths.get(filePath)));
		} catch (FileNotFoundException e) {
			e.printStackTrace();
		} catch (IOException e) {
			e.printStackTrace();
		}
		return "";
	}
}
