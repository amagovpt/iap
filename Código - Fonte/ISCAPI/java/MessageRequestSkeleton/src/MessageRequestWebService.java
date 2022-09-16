import javax.jws.WebService;
import javax.jws.WebMethod;
import javax.jws.soap.SOAPBinding;
import javax.jws.soap.SOAPBinding.Style;

@WebService(targetNamespace = "http://ama.gov.pt")
@SOAPBinding(style = Style.RPC)
public interface MessageRequestWebService {
	@WebMethod String messageRequest();
}
