--针对S_T数据库
--1.	显示所有院系，并在结果集中增加一列字段“院系规模”，其中若该院系人数>=5则该字段值为“规模很大”，若该院系人数大于等于4小于5则该字段值为“规模一般”， 若该院系人数大于等于2小于4则该字段值为“规模稍小”，否则显示“规模很小”；
select sdept,院系规模=case 
                      when count(*)>=5 then '规模很大'
					  when count(*)>=4 and count(*)<5 then '规模一般'
					  when count(*)>=2 and count(*)<4 then '规模稍小'
					  else '规模很小'
					  end
from student
group by sdept
--2.	显示学生信息表中的学生总人数及平均年龄，在结果集中列标题分别指定为“学生总人数，平均年龄”；
select 学生总人数=count(*),平均年龄=avg(sage)
from student
--3.	显示选修的课程数大于3的各个学生的选修课程数；
select sno ,选修课程数=count(cno)
from sc
group by sno
having count(cno)>=3
--4.	按课程号降序显示选修各个课程的总人数、最高成绩、最低成绩及平均成绩；
select cno ,选课总人数=count(*),最高成绩=max(grade),最低成绩=min(grade),平均成绩=avg(grade)
from sc
group by cno
order by cno desc
--5.	列出有二门以上课程（含两门）不及格的学生的学号及不及格门数；
select sno,不及格门数=count(*)
from sc
where grade<60
group by sno
having count(*)>=2
--针对company数据库
--1、在员工表employee中统计员工人数。
select COUNT(*) 人数 from employee
--2、统计各部门员工的员工人数及平均薪水。
select dept,COUNT(*) 人数,AVG(salary) 平均工资
from employee
group by dept
--3、查询销售业绩超过10000元的员工编号。
select sale_id
from sales
group by sale_id
having SUM(tot_amt)>10000
--4、计算每一产品销售数量总和与平均销售单价。
select prod_id,SUM(qty) 销售数量总和,SUM(qty*unit_price)/SUM(qty) 平均销售单价
from sale_item
group by prod_id
--5、统计各部门不同性别、或各部门、或不同性别或所有员工的平均薪水。（在GROUP  BY 子句中使用CUBE关键字）
select dept,sex,AVG(salary)
from employee
group by dept,sex with cube
--6、统计各部门不同性别、或各部门或所有员工的平均薪水。（在GROUP  BY 子句中使用ROLLUP关键字）
select dept,sex,AVG(salary)
from employee
group by dept,sex with rollup
--7、计算出一共销售了几种产品。
select  COUNT(distinct prod_id)
from sale_item
--8、显示sale_item表中每种产品的订购金额总和，并且依据销售金额由大到小排列来显示出每一种产品的排行榜。
select prod_id,SUM(qty*unit_price) 订购金额总和
from sale_item
group by prod_id
order by 订购金额总和  desc
--9、计算每一产品每月的销售金额总和，并将结果按销售（月份，产品编号）排序。
select prod_id,MONTH(order_date) 月份,sum(qty*unit_price) 销售金额总和
from sale_item
group by prod_id,MONTH(order_date)
order by 月份,prod_id
--10、查询每位业务员各个月的业绩，并按业务员编号、月份降序排序。
select sale_id,MONTH(order_date) 月份,SUM(tot_amt) 销售业绩
from sales
group by sale_id,MONTH(order_date)
order by sale_id desc,MONTH(order_date) desc