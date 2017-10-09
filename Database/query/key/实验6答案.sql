select * from student
select * from course
--针对S_T数据库
--1.	查询名字中第2个字为‘勇’的学生姓名和学号及选修的课程号、课程名；
select sname,a.sno,b.cno,cname
from student a,sc b,course c
where a.sno=b.sno and b.cno=c.cno and sname like '_勇%'
--2.	列出选修了‘数学’或者‘数据库’的学生学号、姓名、所在院系、选修课程号及成绩；
select a.sno,sname,sdept,b.cno,grade
from student a,sc b,course c
where a.sno=b.sno and b.cno=c.cno and cname in('数学','数据库')
--3.	查询与‘张立’(假设姓名唯一)年龄不同的所有学生的信息；
select b.*
from student a,student b
where a.sage<>b.sage and a.sno>b.sno and a.sname='张立'
--4.	按照“学号，姓名，所在院系，已修学分”的顺序列出学生学分的获得情况。其中已修学分为考试已经及格的课程学分之和；
select a.sno,sname,sdept,已修学分=sum(ccredit)
from student a,sc b,course c
where a.sno=b.sno and b.cno=c.cno and grade>=60
group by a.sno,sname,sdept

--5.	列出所有课程被选修的详细情况，包括课程号、课程名、学号、姓名及成绩；
select b.cno,cname,a.sno,sname,grade
from student a,sc b,course c
where a.sno=b.sno and b.cno=c.cno
order by b.cno
--6.列出与‘李勇’在一个院系的学生的信息；
select b.*
from student a,student b
where a.sdept=b.sdept and a.sname='李勇' and b.sname<>'李勇'
--7.	查询同时选修了‘1’号课程与‘2’号课程的学生学号；
select a.sno
from sc a ,sc b
where a.sno=b.sno and a.cno='1' and b.cno='2'
--8.	查询至少选修了一门间接先行课为“5”号课程的学生姓名；
select sname
from course a,course b ,sc c ,student d
where a.cpno=b.cno and b.cpno='5'and a.cno=c.cno and c.sno =d.sno
--9.分别使用左外连接、右外连接、全外连接查询student表和sc表中学生的姓名，课程号和成绩。
select * from student
select * from sc

select sname,cno,grade
from student a inner join sc b on a.sno=b.sno 


select sname,cno,grade
from student a left join sc b on a.sno=b.sno  --左外连接
 

select sname,cno,grade
from student a right join sc b on a.sno=b.sno  --右外连接

select sname,cno,grade
from student a full join sc b on a.sno=b.sno  --全外连接

--针对company数据库
--1.	查找出employee表中部门相同且住址相同的女员工的姓名、性别、职称、薪水、住址。
select a.emp_name,a.sex,a.dept,a.salary,b.emp_name,b.sex,b.dept,b.salary
from employee a join employee b
on  (a.emp_no!=b.emp_no) and (a.emp_name>b.emp_name) and (a.addr=b.addr)and (a.dept=b.dept) and a.sex='女' and b.sex='女'

--2.	检索product 表和sale_item表中相同产品的产品编号、产品名称、数量、单价。
select a.prod_id,b.prod_name,a.qty,a.unit_price
from sale_item as a inner join product as b 
on (a.prod_id=b.prod_id) 
--3.	检索product 表和sale_item表中单价高于2400元的相同产品的产品编号、产品名称、数量、单价。
select a.prod_id,b.prod_name,a.qty,a.unit_price
from sale_item as a inner join product as b 
on (a.prod_id=b.prod_id) and unit_price>2400
--4.	查询在每张订单中订购金额超过24000元的客户名及其地址。
select cust_name,addr
from sales a, customer b
where a.cust_id=b.cust_id and a.tot_amt>24000
--5.	查找有销售记录的客户编号、名称和订单总额
select a.cust_id,a.cust_name,SUM(tot_amt) 订单总额
from customer a,sales b
where a.cust_id=b.cust_id
group by a.cust_id,a.cust_name
--6.	每位客户订购的每种产品的总数量及平均单价，并按客户号，产品号从小到大排列。
select cust_id,prod_id,SUM(qty) 总数量,SUM(qty*unit_price)/SUM(qty) 平均单价
from sales a,sale_item b
where a.order_no=b.order_no
group by cust_id,prod_id
order by cust_id,prod_id
--7.	查找在1996年中有销售记录的客户编号、名称和订单总额
select b.cust_id,cust_name,SUM(tot_amt) 订单总额
from sales a, customer b
where a.cust_id=b.cust_id  and year(order_date)=1996
group by b.cust_id,cust_name
--8.	查询1996年销售数量排名前五名的产品编号，产品名称和产品销售数量。
select top 5  a.prod_id,prod_name,sum(qty) as 销售数量
from sale_item a ,product b
where a.prod_id=b.prod_id and YEAR(order_date)=1996
group by a.prod_id,prod_name
order by 销售数量 desc
--9.	分别使用左外连接、右外连接、全外连接检索product 表和sale_item表中单价高于2400元的相同产品的产品编号、产品名称、数量、单价。并分析比较检索的结果。  
select a.prod_id,prod_name,qty,unit_price
from product a join sale_item b
on a.prod_id=b.prod_id and unit_price>2400  --内连接

select a.prod_id,prod_name,qty,unit_price
from product a join sale_item b
on a.prod_id=b.prod_id 
where unit_price>2400  --内连接

select a.prod_id,prod_name,qty,unit_price
from product a left join sale_item b
on a.prod_id=b.prod_id and unit_price>2400 --左外连接

select a.prod_id,prod_name,qty,unit_price
from product a left join sale_item b
on a.prod_id=b.prod_id 
where unit_price>2400 --左外连接

select a.prod_id,prod_name,qty,unit_price
from product a right join sale_item b
on a.prod_id=b.prod_id and unit_price>2400  --右外连接

select a.prod_id,prod_name,qty,unit_price
from product a right join sale_item b
on a.prod_id=b.prod_id 
where unit_price>2400  --右外连接

select a.prod_id,prod_name,qty,unit_price
from product a  full join sale_item b
on a.prod_id=b.prod_id and unit_price>2400  --全外连接

select a.prod_id,prod_name,qty,unit_price
from product a  full join sale_item b
on a.prod_id=b.prod_id
where unit_price>2400  --全外连接


