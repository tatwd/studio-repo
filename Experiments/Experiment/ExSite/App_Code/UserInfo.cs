using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// UserInfo 类包含Name和Birthday两个属性及一个DecideAge()方法
/// </summary>
public class UserInfo
{
    private string   _Name;
    private DateTime _Birthday;

    /// <summary>
    /// 定义Name属性
    /// </summary>
    public string Name
    {
        get { return _Name; }
        set { _Name = value; }
    }

    /// <summary>
    /// 定义Birthday属性
    /// </summary>
    public DateTime Birthday
    {
        get { return _Birthday; }
        set { _Birthday = value; }
    }

    /// <summary>
    /// 定义构造函数
    /// <para name="name">姓名</para>
    /// <para name="birthday">生日</para>
    /// </summary>
    public UserInfo(string name, DateTime birthday)
    {
        this._Name     = name;
        this._Birthday = birthday;
    }

    /// <summary>
    /// DecideAge()用于判断用户是否达到规定年龄
    /// </summary>
    /// <return>
    /// 当年龄大于等于18岁返回“xxx，你是成年人了！”，否则返回值“xxx，你还没长大呢？”。
    /// </return>
    public string DecideAge()
    {
        //if (DateTime.Now.Year - _Birthday.Year < 18)
        //{
        //    return this._Name + "，你还没长大呢？";
        //}
        //else
        //{
        //    return this._Name + "，你是成人呢！";
        //}

        if (DateTime.Now < _Birthday || _Birthday < DateTime.Parse("1900-1-1"))
        {
            return ValidateBirthday();
        }

        return "生日值不大于当前日期也不小于1900-1-1";

    }

    /// <summary>
    /// ValidateBirthday()用于验证生日是否大于当前日期或小于1900-1-1
    /// </summary>
    /// <returns>
    /// 当生日值大于当前日期或小于1900-1-1，在DecideAge()被触发，返回“生日值大于当前日期或小于1900-1-1”。
    /// </returns>
    public string ValidateBirthday()
    {
        return "生日值大于当前日期或小于1900-1-1";
    }
}