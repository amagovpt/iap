import javax.jws.WebService;

@WebService(endpointInterface = "MessageRequestWebService",
targetNamespace = "http://ama.gov.pt")
public class MessageRequestWebServiceImpl implements MessageRequestWebService {

	private String endpoint;
	
	private String SOAPAction;
	
	private String message;
	
	public MessageRequestWebServiceImpl(String endpoint, String SOAPAction, String message) {
		this.endpoint = endpoint;
		this.SOAPAction = SOAPAction;
		this.message = message;
	}
	
	@Override
	public String messageRequest() {
		try {
			SOAPClient soapClient = new SOAPClient(endpoint);
			soapClient.sendMessage(message, SOAPAction);
		} catch (Exception e) {
			e.printStackTrace();
		}
		return "ok";
	}

}
