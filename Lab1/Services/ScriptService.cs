namespace Lab1.Services
{
    public class ScriptService : IScriptService
    {
        public async Task<bool> PostScript(string script)
        {
            if (string.IsNullOrWhiteSpace(script)) return false;
            if (script == "1") return false;
            return true;
        }
    }
}
