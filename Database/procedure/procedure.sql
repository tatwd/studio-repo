USE company

GO

-- 1、利用存储过程，给employee表添加一条业务部门员工的信息。

CREATE PROCEDURE emp_insert(
    @emp_no CHAR(5),
    @emp_name CHAR(10),
    @sex CHAR(2),
    @title CHAR(6),
    @date_hired DATETIME,
    @birthday DATETIME,
    @salary INT,
    @telephone VARCHAR(20),
    @addr CHAR(50)
)
AS
    INSERT INTO employee
    VALUES(@emp_no, @emp_name, @sex, '业务', @title, @date_hired, @birthday, @salary, @telephone, @addr)

GO

EXEC emp_insert 'E0021', 'Leo', '男',  '经理', '2017-10-19', '1996-11-11', 8000, '18170826687', '江西南昌' 

GO

-- 2、利用存储过程从employee、sales、customer表的连接中返回所有业务员的姓名、客户姓名、销售金额。

CREATE PROCEDURE get_emp_sale_cust
AS
    SELECT emp_name, cust_name, tot_amt
    FROM employee, sales, customer
    WHERE employee.emp_no = sales.sale_id
        AND sales.cust_id = customer.cust_id
GO

EXEC get_emp_sale_cust

GO

-- 3、创建带一个输入参数的存储过程，实现按员工姓名进行模糊查找，查找员工编号、订单编号、销售金额。

CREATE PROCEDURE emp_query(@emp_name CHAR(10))
AS
    SELECT sale_id, order_no, tot_amt
    FROM employee, sales
    WHERE emp_name = @emp_name
        AND employee.emp_no = sales.sale_id
GO

-- EXEC emp_query '刘刚'

GO

-- 4、创建带两个输入参数的存储过程，查找姓“李”并且职称为“职员”的员工编号、订单编号、销售金额。
-- 5、利用存储过程计算出订单编号为10003的订单的销售金额。（带一输入参数和一输出参数）（提示：sales表中的tot_amt应该等于sale_item表中的同一张订单的不同销售产品的qty*unit_price之和）
-- 6、创建一存储过程，根据给出的职称，返回该职称的所有员工的平均工资。（带一输入参数和返回值）
-- 7、请创建一个存储过程，修改sales表中的订单金额tot_amt，使之等于各订单对应的所有订单明细的数量与单价的总和。

-- DROP PROCEDURE emp_query

-- SELECT * FROM employee

-- DELETE FROM employee WHERE emp_no = 'E0021'

-- SELECT * FROM sales