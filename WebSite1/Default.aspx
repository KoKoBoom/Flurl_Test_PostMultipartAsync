<%@ Page Language="C#" %>

<%
    StringBuilder str = new StringBuilder();
    for (int i = 0; i < Request.Form.Count; i++)
    {
        str.AppendLine("    " + Request.Form.GetKey(i) + ":" + Request.Form[i]);
    }
    for (int i = 0; i < HttpContext.Current.Request.Files.Count; i++)
    {
        str.AppendLine("FileName:" + HttpContext.Current.Request.Files[i].FileName);
    }
    Response.Write("Form.Count：" + Request.Form.Count + "\r\nfileList.Count:" + HttpContext.Current.Request.Files.Count + "\r\nkeyValue:\r\n" + str);
%>
