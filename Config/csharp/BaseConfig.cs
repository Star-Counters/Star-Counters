namespace Config{
	public class BaseConfig{
		public BaseConfig(string str){

		}
        protected string[] ConvertStringToArray(string str) {
            return str.Split('|');
        }
	}
}