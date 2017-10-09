/*
Navicat MySQL Data Transfer

Source Server         : localhost
Source Server Version : 50717
Source Host           : localhost:3306
Source Database       : dangdang

Target Server Type    : MYSQL
Target Server Version : 50717
File Encoding         : 65001

Date: 2017-10-07 21:07:45
*/

use dangdang;

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for book
-- ----------------------------
DROP TABLE IF EXISTS `book`;
CREATE TABLE `book` (
  `book_id` char(8) NOT NULL,
  `book_name` varchar(30) DEFAULT NULL,
  `author` varchar(20) DEFAULT NULL,
  `press` varchar(30) DEFAULT NULL COMMENT '出版社',
  `price` decimal(7,2) DEFAULT NULL COMMENT '原价',
  `dd_price` decimal(7,2) DEFAULT NULL COMMENT '当当价',
  PRIMARY KEY (`book_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='图书表';

-- ----------------------------
-- Records of book
-- ----------------------------
INSERT INTO `book` VALUES ('41001001', '人间失格', '太宰治', '作家出版社', '25.00', '18.80');
INSERT INTO `book` VALUES ('41001002', '追风筝的人', '卡勒德·胡塞尼', '上海人民出版社', '29.00', '22.10');
INSERT INTO `book` VALUES ('41001003', '我喜欢生命本来的样子', '周平国', '作家出版社', '45.00', '38.20');
INSERT INTO `book` VALUES ('41001004', '解忧杂货店', '东野圭吾', '南海出版社', '39.50', '27.30');
INSERT INTO `book` VALUES ('41001005', '刘心武续红楼梦', '刘心武', '人民文学出版社', '45.00', '35.50');
INSERT INTO `book` VALUES ('41001006', '子不语', '袁枚', '天津人民出版社', '39.80', '25.80');
INSERT INTO `book` VALUES ('41001007', '论语别裁', '南怀瑾', '复旦大学出版社', '78.00', '46.60');
INSERT INTO `book` VALUES ('41001008', '活出生命的意义', '弗兰克尔', '华夏出版社', '39.80', '23.50');
INSERT INTO `book` VALUES ('41001009', '人间词话', '王国维', '北京联合出版公司', '29.80', '22.40');
INSERT INTO `book` VALUES ('41001010', '摆渡人', '克莱儿·麦克福尔', '百花洲文艺出版社', '36.00', '26.70');
INSERT INTO `book` VALUES ('41001011', '傻瓜维特', '乔辛·迪·波沙达', '现代出版社', '30.00', '22.60');
INSERT INTO `book` VALUES ('41001012', '阿里巴巴人力资源管理', '陈伟', '古吴轩出版社', '45.00', '37.60');
INSERT INTO `book` VALUES ('41001013', '边城', '沈从文', '北京燕山出版社', '15.00', '13.30');
INSERT INTO `book` VALUES ('41001014', '我不', '大冰', '湖南文艺轩出版社', '39.00', '29.00');

-- ----------------------------
-- Table structure for book_favorite
-- ----------------------------
DROP TABLE IF EXISTS `book_favorite`;
CREATE TABLE `book_favorite` (
  `favorite_id` int(11) NOT NULL AUTO_INCREMENT,
  `user_id` char(8) DEFAULT NULL,
  `book_id` char(8) DEFAULT NULL,
  PRIMARY KEY (`favorite_id`),
  KEY `fk_user_f_idx` (`user_id`),
  KEY `fk_book_d_idx` (`book_id`),
  CONSTRAINT `fk_book_d` FOREIGN KEY (`book_id`) REFERENCES `book` (`book_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_user_f` FOREIGN KEY (`user_id`) REFERENCES `user` (`user_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=1011 DEFAULT CHARSET=utf8 COMMENT='收藏图书表';

-- ----------------------------
-- Records of book_favorite
-- ----------------------------
INSERT INTO `book_favorite` VALUES ('1001', '20171001', '41001001');
INSERT INTO `book_favorite` VALUES ('1002', '20171002', '41001001');
INSERT INTO `book_favorite` VALUES ('1003', '20171004', '41001011');
INSERT INTO `book_favorite` VALUES ('1004', '20171004', '41001001');
INSERT INTO `book_favorite` VALUES ('1005', '20171004', '41001002');
INSERT INTO `book_favorite` VALUES ('1006', '20171005', '41001003');
INSERT INTO `book_favorite` VALUES ('1007', '20171006', '41001005');
INSERT INTO `book_favorite` VALUES ('1008', '20171007', '41001007');
INSERT INTO `book_favorite` VALUES ('1009', '20171008', '41001007');
INSERT INTO `book_favorite` VALUES ('1010', '20171010', '41001006');

-- ----------------------------
-- Table structure for cart
-- ----------------------------
DROP TABLE IF EXISTS `cart`;
CREATE TABLE `cart` (
  `cart_id` char(8) NOT NULL,
  `user_id` char(8) DEFAULT NULL,
  `book_id` char(8) DEFAULT NULL,
  `quantity` int(11) DEFAULT NULL COMMENT '数量',
  PRIMARY KEY (`cart_id`),
  KEY `fk_user_e_idx` (`user_id`),
  KEY `fk_book_c_idx` (`book_id`),
  CONSTRAINT `fk_book_c` FOREIGN KEY (`book_id`) REFERENCES `book` (`book_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_user_e` FOREIGN KEY (`user_id`) REFERENCES `user` (`user_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='购物车信息表';

-- ----------------------------
-- Records of cart
-- ----------------------------
INSERT INTO `cart` VALUES ('31001001', '20171001', '41001001', '1');
INSERT INTO `cart` VALUES ('31001002', '20171001', '41001002', '1');
INSERT INTO `cart` VALUES ('31001003', '20171002', '41001005', '2');
INSERT INTO `cart` VALUES ('31001004', '20171003', '41001008', '1');
INSERT INTO `cart` VALUES ('31001005', '20171003', '41001007', '2');
INSERT INTO `cart` VALUES ('31001006', '20171003', '41001006', '1');
INSERT INTO `cart` VALUES ('31001007', '20171006', '41001003', '1');
INSERT INTO `cart` VALUES ('31001008', '20171008', '41001001', '3');
INSERT INTO `cart` VALUES ('31001009', '20171009', '41001011', '1');

-- ----------------------------
-- Table structure for category
-- ----------------------------
DROP TABLE IF EXISTS `category`;
CREATE TABLE `category` (
  `book_id` char(8) NOT NULL,
  `category_1` varchar(10) DEFAULT NULL COMMENT '一级分类',
  `category_2` varchar(10) DEFAULT NULL COMMENT '二级分类',
  `category_3` varchar(20) DEFAULT NULL COMMENT '三级分类',
  `category_4` varchar(20) DEFAULT NULL COMMENT '四级分类',
  KEY `fk_book_idx` (`book_id`),
  CONSTRAINT `fk_book` FOREIGN KEY (`book_id`) REFERENCES `book` (`book_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='分类表';

-- ----------------------------
-- Records of category
-- ----------------------------
INSERT INTO `category` VALUES ('41001001', '图书', '小说', '社会', null);
INSERT INTO `category` VALUES ('41001001', '图书', '小说', '外国小说', '日本');
INSERT INTO `category` VALUES ('41001002', '图书', '小说', '情感', '其他');
INSERT INTO `category` VALUES ('41001002', '图书', '小说', '外国小说', '美国');
INSERT INTO `category` VALUES ('41001003', '图书', '文学', '文集', null);
INSERT INTO `category` VALUES ('41001004', '图书', '小说', '社会', null);
INSERT INTO `category` VALUES ('41001004', '图书', '小说', '外国小说', '日本');
INSERT INTO `category` VALUES ('41001005', '图书', '文学', '文学评论与鉴赏', null);
INSERT INTO `category` VALUES ('41001006', '图书', '小说', '魔幻', null);
INSERT INTO `category` VALUES ('41001007', '图书', '哲学/宗教', '哲学', '中国古代哲学');
INSERT INTO `category` VALUES ('41001008', '图书', '哲学/宗教', '哲学', '哲学知识读物');
INSERT INTO `category` VALUES ('41001009', '图书', '文学', '中国古诗词', null);
INSERT INTO `category` VALUES ('41001010', '图书', '小说', '社会', null);
INSERT INTO `category` VALUES ('41001010', '图书', '小说', '外国小说', '英国');
INSERT INTO `category` VALUES ('41001011', '图书', '成功/励志', '人生哲学', '人生选择与改变');
INSERT INTO `category` VALUES ('41001012', '图书', '管理', '一般管理学', '人力资源/行政管理');
INSERT INTO `category` VALUES ('41001013', '图书', '小说', '乡土', null);
INSERT INTO `category` VALUES ('41001013', '图书', '小说', '中国当代小说', null);
INSERT INTO `category` VALUES ('41001014', '图书', '小说', '作品集', '中国');
INSERT INTO `category` VALUES ('41001014', '图书', '小说', '中国当代小说', null);

-- ----------------------------
-- Table structure for comment
-- ----------------------------
DROP TABLE IF EXISTS `comment`;
CREATE TABLE `comment` (
  `comment_id` char(8) NOT NULL,
  `book_id` char(8) DEFAULT NULL,
  `user_id` char(8) DEFAULT NULL,
  `comment_content` varchar(4000) DEFAULT NULL COMMENT '评论内容',
  `comment_date` datetime DEFAULT NULL,
  `zan_count` int(11) unsigned zerofill DEFAULT NULL COMMENT '赞数',
  `cai_count` int(11) unsigned zerofill DEFAULT NULL COMMENT '踩数',
  PRIMARY KEY (`comment_id`),
  KEY `fk_book_a_idx` (`book_id`),
  KEY `fk_user_b_idx` (`user_id`),
  CONSTRAINT `fk_book_a` FOREIGN KEY (`book_id`) REFERENCES `book` (`book_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_user_b` FOREIGN KEY (`user_id`) REFERENCES `user` (`user_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='评论表';

-- ----------------------------
-- Records of comment
-- ----------------------------
INSERT INTO `comment` VALUES ('81001001', '41001009', '20171001', '为什么唐诗之后几乎再无好诗？因为最好的情绪意境已经有人写了，想表达时借用好过拿新的；为什么宋词之后只有个纳兰性德呢？因为他来不及熟练地借用前，已经才华横溢地学会写了。', '2017-07-25 19:41:36', '00000000037', '00000000008');
INSERT INTO `comment` VALUES ('81001002', '41001014', '20171006', '所谓英雄，或许大都是如此这般自惭着的吧。 锁心苦行，把自己囚禁在真挚中，真挚到荒谬。 一瞬间有被一种戳心窝子的感觉，一如既往大冰的语调，却总能直指人心，我想这就是为什么我们这么爱他的原因吧', '2017-08-21 20:30:00', '00000000094', '00000000024');
INSERT INTO `comment` VALUES ('81001003', '41001001', '20171007', '纪德曾说“我因鞭笞自己而感到喜悦，喜悦自己的无处逃避--其中有莫大的骄傲，在身处罪恶时。” 这也是太宰治的真实写照吧，自我矛盾的人生，完美主义的追求。让我在序言中就感到压抑。这或许也是太宰治的写作风格?', '2017-07-27 11:20:52', '00000000154', '00000000063');
INSERT INTO `comment` VALUES ('81001004', '41001002', '20171008', '风筝是什么呢？在我看来，至少有着希望，它是阿米尔被父亲赞赏的希望，是哈桑守护友情的希望，是索拉博眼中的闪光。阿米尔更擅长斗风筝，更有心机，操纵着手中的线。阿米尔，得到了赎罪后的解脱，还是陷身于命运的漩涡呢！唉', '2017-06-15 15:10:26', '00000000064', '00000000029');
INSERT INTO `comment` VALUES ('81001005', '41001002', '20171009', '文章写的很感人，哈桑对阿米尔的衷心，对阿米尔的呵护让我流泪！阿米尔对哈桑的愧疚充满了字里行间，但通过自身的救赎，弥补了内心的伤痕。尽管哈桑已经不在人间，但阿米尔把自己的爱全心全意的付出与小哈桑索拉博的身上。', '2017-05-22 16:57:58', '00000000017', '00000000003');
INSERT INTO `comment` VALUES ('81001006', '41001008', '20171010', '本书讲述经历死亡的人从地狱中重生的故事，也许他的经历我们无法复制，也无法切身感受，但是从字里行间，我们可以想象到人在死亡面前，并非无所作为，我喜欢李琦老师的一句话，作为一个人，要有向死而生的勇气。', '2016-11-12 16:41:07', '00000000006', '00000000000');
INSERT INTO `comment` VALUES ('81001007', '41001013', '20171008', '一曲对“美”与“爱”的悲哀赞歌，更是对故土湘西的乡土风俗的优美挽歌。渡船被冲走了、白塔坍塌了、爷爷死了，苗族的古老历史也被割断了。美学家朱光潜说边城表现了受到长期压迫而又富于幻想和敏感的少数民族心坎那一股沉郁隐痛。', '2017-09-20 15:05:40', '00000000001', '00000000000');

-- ----------------------------
-- Table structure for consignee
-- ----------------------------
DROP TABLE IF EXISTS `consignee`;
CREATE TABLE `consignee` (
  `consignee_id` int(11) NOT NULL AUTO_INCREMENT,
  `user_id` char(8) DEFAULT NULL,
  `consignee` varchar(20) DEFAULT NULL COMMENT '收货人',
  `telephone` varchar(15) DEFAULT NULL,
  `consignee_address` varchar(40) DEFAULT NULL,
  `zip_code` char(6) DEFAULT NULL COMMENT '邮编',
  PRIMARY KEY (`consignee_id`),
  KEY `fk_user_idx` (`user_id`),
  CONSTRAINT `fk_user` FOREIGN KEY (`user_id`) REFERENCES `user` (`user_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8 COMMENT='收货人信息表';

-- ----------------------------
-- Records of consignee
-- ----------------------------
INSERT INTO `consignee` VALUES ('11', '20171001', '刘备', '13537777388', '北京市朝阳区中国传媒大学', '100024');
INSERT INTO `consignee` VALUES ('12', '20171003', '关羽', '18170826687', '江西省南昌市江西师范大学', '330001');
INSERT INTO `consignee` VALUES ('13', '20171007', '李琳', '15777770130', '湖南省长沙市岳麓山区湖南大学', '410082');
INSERT INTO `consignee` VALUES ('14', '20171009', '曹操', '13512960022', '上海市杨浦区复旦大学', '200433');
INSERT INTO `consignee` VALUES ('15', '20171010', '貂蝉', '15824817777', '湖北省武汉市武昌区武汉大学', '430072');

-- ----------------------------
-- Table structure for order
-- ----------------------------
DROP TABLE IF EXISTS `order`;
CREATE TABLE `order` (
  `order_id` char(8) NOT NULL,
  `user_id` char(8) DEFAULT NULL,
  `consignee_id` int(11) DEFAULT NULL COMMENT '收货人ID',
  `order_date` datetime DEFAULT NULL,
  `total_money` decimal(9,2) DEFAULT NULL COMMENT '订单金额',
  `pay_way` varchar(20) DEFAULT NULL COMMENT '支付方式',
  `delivery_way` varchar(20) DEFAULT NULL COMMENT '配送方式',
  PRIMARY KEY (`order_id`),
  KEY `fk_user_a_idx` (`user_id`),
  KEY `fk_consignee_idx` (`consignee_id`),
  CONSTRAINT `fk_consignee` FOREIGN KEY (`consignee_id`) REFERENCES `consignee` (`consignee_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_user_a` FOREIGN KEY (`user_id`) REFERENCES `user` (`user_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='订单表';

-- ----------------------------
-- Records of order
-- ----------------------------
INSERT INTO `order` VALUES ('61710001', '20171002', '11', '2016-12-21 12:55:09', '256.80', '网上支付', '当当快递');
INSERT INTO `order` VALUES ('61710002', '20171001', '11', '2017-06-24 11:29:33', '345.70', '货到付现金', '当当快递');
INSERT INTO `order` VALUES ('61710003', '20171003', '12', '2017-09-04 11:14:45', '996.80', '银行转账', '当当快递');
INSERT INTO `order` VALUES ('61710004', '20171007', '13', '2017-09-03 19:15:55', '56.80', '他人代付', '当当快递');
INSERT INTO `order` VALUES ('61710005', '20171009', '14', '2017-10-01 18:26:41', '86.60', '货到支付宝支付', '当当快递');
INSERT INTO `order` VALUES ('61710006', '20171009', '14', '2017-10-03 18:26:42', '59.80', '网上支付', '当当快递');
INSERT INTO `order` VALUES ('61710007', '20171010', '15', '2017-10-07 11:49:22', '156.80', '网上支付', '当当快递');

-- ----------------------------
-- Table structure for order_item
-- ----------------------------
DROP TABLE IF EXISTS `order_item`;
CREATE TABLE `order_item` (
  `order_id` char(8) NOT NULL,
  `quantity` int(11) DEFAULT NULL COMMENT '数量',
  `total_money` decimal(9,2) DEFAULT NULL,
  KEY `fk_idx` (`order_id`),
  CONSTRAINT `fk_order` FOREIGN KEY (`order_id`) REFERENCES `order` (`order_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='订单明细表';

-- ----------------------------
-- Records of order_item
-- ----------------------------
INSERT INTO `order_item` VALUES ('61710001', '4', '256.80');
INSERT INTO `order_item` VALUES ('61710002', '6', '345.70');
INSERT INTO `order_item` VALUES ('61710003', '12', '996.80');
INSERT INTO `order_item` VALUES ('61710004', '1', '56.80');
INSERT INTO `order_item` VALUES ('61710005', '1', '86.60');
INSERT INTO `order_item` VALUES ('61710006', '1', '59.80');
INSERT INTO `order_item` VALUES ('61710007', '2', '156.80');

-- ----------------------------
-- Table structure for question
-- ----------------------------
DROP TABLE IF EXISTS `question`;
CREATE TABLE `question` (
  `question_id` char(8) NOT NULL,
  `user_id` char(8) DEFAULT NULL,
  `book_id` char(8) DEFAULT NULL,
  `question_type` varchar(10) DEFAULT NULL COMMENT '提问类型（商品咨询/支付问题/配送问题/退换商品/发票及促销）',
  `question_content` varchar(1000) DEFAULT NULL,
  `reply_count` int(11) unsigned zerofill DEFAULT NULL COMMENT '回复数',
  `question_date` datetime DEFAULT NULL,
  `verify_status` char(4) DEFAULT NULL COMMENT '审核状态（通过/阻止）',
  PRIMARY KEY (`question_id`),
  KEY `fk_user_c_idx` (`user_id`),
  KEY `fk_book_b_idx` (`book_id`),
  CONSTRAINT `fk_book_b` FOREIGN KEY (`book_id`) REFERENCES `book` (`book_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_user_c` FOREIGN KEY (`user_id`) REFERENCES `user` (`user_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='提问表';

-- ----------------------------
-- Records of question
-- ----------------------------
INSERT INTO `question` VALUES ('91001001', '20171001', '41001001', '商品咨询', '和《摆渡人》一起下单，能免邮费么？', '00000000001', '2015-09-10 18:09:43', '通过');
INSERT INTO `question` VALUES ('91001002', '20171004', '41001008', '商品咨询', '跟《人生四书》一起下单的，能免邮费么？', '00000000001', '2016-11-29 14:19:13', '通过');
INSERT INTO `question` VALUES ('91001003', '20171005', '41001004', '商品咨询', '请问《谷园讲通鉴》有货了吗？', '00000000001', '2016-11-29 14:18:46', '通过');
INSERT INTO `question` VALUES ('91001004', '20171007', '41001007', '商品咨询', '复旦出版的南师是繁体字的吗？', '00000000001', '2016-11-30 10:36:49', '通过');
INSERT INTO `question` VALUES ('91001005', '20171009', '41001010', '发票及促销', '跟谷园《人生四书》一起下单，能开增值税发票么？', '00000000001', '2015-09-10 18:09:43', '通过');
INSERT INTO `question` VALUES ('91001006', '20171008', '41001010', '商品咨询', 'ssssssssssssssssssssssbbbbbbbbbbbbbbbbbbbbbbbb', '00000000000', '2015-09-10 18:09:43', '阻止');

-- ----------------------------
-- Table structure for reply
-- ----------------------------
DROP TABLE IF EXISTS `reply`;
CREATE TABLE `reply` (
  `question_id` char(8) NOT NULL,
  `reply_user_id` char(8) DEFAULT NULL COMMENT '回复人ID',
  `reply_content` varchar(1000) DEFAULT NULL,
  `reply_date` datetime DEFAULT NULL,
  KEY `fk_user_d_idx` (`reply_user_id`),
  KEY `fk_question_idx` (`question_id`),
  CONSTRAINT `fk_question` FOREIGN KEY (`question_id`) REFERENCES `question` (`question_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_user_d` FOREIGN KEY (`reply_user_id`) REFERENCES `user` (`user_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='问题回复表';

-- ----------------------------
-- Records of reply
-- ----------------------------
INSERT INTO `reply` VALUES ('91001001', '20040001', '您好，当当页面上的价格已经是优惠后的价格了，无法在给您其他的优惠价格出售，还请您以实际提交订单金额为准，感谢您对当当的支持，祝您购物愉快！', '2015-09-11 18:09:43');
INSERT INTO `reply` VALUES ('91001002', '20171011', '当当自营订单普通快递：全国（除西北五省）普通快递送货上门和平邮订单，每单满49元以上免运费，西北五省（新疆、西藏、甘肃、宁夏、青海）每单满59元以上免运费，不足以上免运费标准的，每单收取5元运费。', '2016-11-30 14:19:13');
INSERT INTO `reply` VALUES ('91001003', '20040001', '您好，首先建议您在搜索栏输入商品名称，根据提示打开对应单品页面，您在单品页选择您所在的城市，系统就会提示能否送到您所在地区,若您所在地区不在区域范围内，则无法购买,请您谅解。请您了解，谢谢！', '2016-11-30 14:18:46');
INSERT INTO `reply` VALUES ('91001004', '20171003', '您好，本商品为中文简体版，感谢您的关注，祝您购物愉快，谢谢！', '2016-11-30 10:48:49');
INSERT INTO `reply` VALUES ('91001005', '20040001', '您好，根据财税【2013】87号文第二条“免征图书批发、零售环节增值税”的要求，当当从2013年1月1日至2017年12月31日期间，销售的图书只提供普通发票，不再开具增值税专用发票；请您了解，谢谢！', '2015-09-10 18:20:43');

-- ----------------------------
-- Table structure for store
-- ----------------------------
DROP TABLE IF EXISTS `store`;
CREATE TABLE `store` (
  `store_id` int(11) NOT NULL AUTO_INCREMENT,
  `store_name` varchar(40) DEFAULT NULL,
  `store_address` varchar(40) DEFAULT NULL,
  PRIMARY KEY (`store_id`)
) ENGINE=InnoDB AUTO_INCREMENT=107 DEFAULT CHARSET=utf8 COMMENT='店铺表';

-- ----------------------------
-- Records of store
-- ----------------------------
INSERT INTO `store` VALUES ('101', '北京天下智慧文化传播有限公司', '中国北京');
INSERT INTO `store` VALUES ('102', '当当自出版品牌旗舰店', '中国北京');
INSERT INTO `store` VALUES ('103', '生活·读书·新知三联书店有限公', '中国北京');
INSERT INTO `store` VALUES ('104', '中南博集天卷文化传媒有限公司', '中国天津');
INSERT INTO `store` VALUES ('105', '新经典发行有限公司', '中国北京');
INSERT INTO `store` VALUES ('106', '中华书局有限公司', '中国北京');

-- ----------------------------
-- Table structure for store_collect
-- ----------------------------
DROP TABLE IF EXISTS `store_collect`;
CREATE TABLE `store_collect` (
  `collect_id` int(11) NOT NULL AUTO_INCREMENT,
  `user_id` char(8) DEFAULT NULL,
  `store_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`collect_id`),
  KEY `fk_user_g_idx` (`user_id`),
  KEY `fk_store_idx` (`store_id`),
  CONSTRAINT `fk_store` FOREIGN KEY (`store_id`) REFERENCES `store` (`store_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_user_g` FOREIGN KEY (`user_id`) REFERENCES `user` (`user_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=210 DEFAULT CHARSET=utf8 COMMENT='收藏店铺表';

-- ----------------------------
-- Records of store_collect
-- ----------------------------
INSERT INTO `store_collect` VALUES ('201', '20171002', '101');
INSERT INTO `store_collect` VALUES ('202', '20171003', '104');
INSERT INTO `store_collect` VALUES ('203', '20171003', '102');
INSERT INTO `store_collect` VALUES ('204', '20171003', '103');
INSERT INTO `store_collect` VALUES ('205', '20171006', '101');
INSERT INTO `store_collect` VALUES ('206', '20171007', '105');
INSERT INTO `store_collect` VALUES ('207', '20171007', '106');
INSERT INTO `store_collect` VALUES ('208', '20171008', '101');
INSERT INTO `store_collect` VALUES ('209', '20171010', '103');

-- ----------------------------
-- Table structure for user
-- ----------------------------
DROP TABLE IF EXISTS `user`;
CREATE TABLE `user` (
  `user_id` char(8) NOT NULL,
  `user_name` varchar(20) DEFAULT NULL,
  `sex` char(2) DEFAULT NULL,
  `user_type` varchar(8) DEFAULT NULL COMMENT '用户身份（在校学生/教师/上班族/自由职业）',
  `phone_number` char(11) DEFAULT NULL,
  `address` varchar(16) DEFAULT NULL,
  `password` varchar(16) DEFAULT NULL,
  PRIMARY KEY (`user_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='用户表';

-- ----------------------------
-- Records of user
-- ----------------------------
INSERT INTO `user` VALUES ('20040001', '当当网', '女', '管理员', null, '中国北京', 'root123456');
INSERT INTO `user` VALUES ('20171001', 'John', '男', '在校学生', '13537777388', '中国北京', 'abc123');
INSERT INTO `user` VALUES ('20171002', 'Marry', '女', '教师', '15219466201', '中国上海', 'abc123');
INSERT INTO `user` VALUES ('20171003', 'Leo', '男', '在校学生', '18170826687', '中国江西', 'abc123');
INSERT INTO `user` VALUES ('20171004', 'Kim', '男', '上班族', '18438888133', '中国天津', 'abc123');
INSERT INTO `user` VALUES ('20171005', '路人甲', '男', '教师', '13467719111', '中国深圳', 'abc123');
INSERT INTO `user` VALUES ('20171006', '路人已', '女', '上班族', '18352936688', '中国北京', 'abc123');
INSERT INTO `user` VALUES ('20171007', '李琳', '女', '在校学生', '15777770130', '中国长沙', 'abc123');
INSERT INTO `user` VALUES ('20171008', '张三', '男', '上班族', '13727693111', '中国北京', 'abc123');
INSERT INTO `user` VALUES ('20171009', '王五', '男', '教师', '13512960022', '中国上海', 'abc123');
INSERT INTO `user` VALUES ('20171010', '多多', '女', '在校学生', '15824817777', '中国武汉', 'abc123');
INSERT INTO `user` VALUES ('20171011', '少少', '男', '自由职业', '18822441999', '中国南京', 'abc123');
