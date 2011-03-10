namespace OauthInOpenRasta.Authentication
{
	public interface IHeaderMapper<T>
	{
		T Map(string headerValue);
	}
}