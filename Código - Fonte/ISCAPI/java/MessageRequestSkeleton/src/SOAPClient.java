import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.io.InputStream;

import javax.xml.soap.*;

public class SOAPClient {

	private String endpoint;
	
	public SOAPClient(String endpoint) {
		this.endpoint = endpoint;
	}

	public void sendMessage(String message, String SOAPAction) throws IOException, SOAPException {
		// criar SOAPMessage
		InputStream is = new ByteArrayInputStream(message.getBytes());
		SOAPMessage request = MessageFactory.newInstance(SOAPConstants.SOAP_1_2_PROTOCOL).createMessage(null, is);
		MimeHeaders headers = request.getMimeHeaders();
		headers.addHeader("Content-Type", "application/soap+xml");
		headers.addHeader("Accept", "application/soap+xml");
		headers.addHeader("SOAPAction", SOAPAction);
		request.saveChanges();

		// criar SOAP Connection
		SOAPConnectionFactory soapConnectionFactory = SOAPConnectionFactory.newInstance();
        SOAPConnection soapConnection = soapConnectionFactory.createConnection();
        
        // fazer a chamada e imprimir a resposta
        SOAPMessage soapResponse = soapConnection.call(request, endpoint);
        System.out.println("Response SOAP Message:");
        soapResponse.writeTo(System.out);
        System.out.println();
	}

}
