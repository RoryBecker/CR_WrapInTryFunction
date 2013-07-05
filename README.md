CR_WrapInTryFunction
====================

A CodeRush plugin which creates a method that wraps the active method in the same way that 'TryParse' wraps 'Parse'.

For example, given the code...

    private string GetString(string P1)
    {
      return "A string";
    }

...the plugin will provide...

    bool TryGetString(string P1, out string result)
    {
        try
        {
            result = GetString(P1);
            return true;
        }
        catch
        {
            result = null;
            return false;
        }
    }

