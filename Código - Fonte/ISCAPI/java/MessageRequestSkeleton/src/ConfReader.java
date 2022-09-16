import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.InputStream;
import java.util.Properties;

public class ConfReader {

	public static Properties getConf() {
		InputStream is = ConfReader.class.getResourceAsStream("/config.conf");
		return getProperties(is);
	}
	
	public static Properties getConf(String filepath) {
		FileInputStream fis = null;
		try {
			fis = new FileInputStream(filepath);
		} catch (FileNotFoundException e) {
			e.printStackTrace();
		};
		return getProperties(fis);
	}
	
	private static Properties getProperties(InputStream is) {
		Properties prop = new Properties();
		try {
		    prop.load(is);
		    prop.list(System.out);
		} catch (IOException ex) {
			ex.printStackTrace();
		}
		return prop;
	}
	
}
