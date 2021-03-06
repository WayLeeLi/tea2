USE [Tea]
GO
/****** Object:  Table [dbo].[shop_users]    Script Date: 08/29/2018 16:35:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[shop_users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[group_id] [int] NULL,
	[user_name] [nvarchar](100) NOT NULL,
	[salt] [nvarchar](20) NULL,
	[password] [nvarchar](100) NOT NULL,
	[mobile] [nvarchar](20) NULL,
	[email] [nvarchar](50) NULL,
	[avatar] [nvarchar](255) NULL,
	[nick_name] [nvarchar](100) NULL,
	[sex] [nvarchar](20) NULL,
	[birthday] [datetime] NULL,
	[telphone] [nvarchar](50) NULL,
	[area] [nvarchar](255) NULL,
	[address] [nvarchar](255) NULL,
	[qq] [nvarchar](20) NULL,
	[msn] [nvarchar](100) NULL,
	[amount] [decimal](9, 2) NULL,
	[point] [int] NULL,
	[exp] [int] NULL,
	[status] [tinyint] NULL,
	[reg_time] [datetime] NULL,
	[reg_ip] [nvarchar](20) NULL,
	[company] [int] NULL,
	[user_hei] [int] NULL,
	[bank] [nvarchar](512) NULL,
	[bank_pic] [nvarchar](128) NULL,
	[bank_hetong] [ntext] NULL,
	[name] [nvarchar](64) NULL,
	[tong_code] [nvarchar](64) NULL,
	[tong_more] [nvarchar](128) NULL,
	[link_name] [nvarchar](64) NULL,
	[link_nichen] [nvarchar](64) NULL,
	[link_mail] [nvarchar](64) NULL,
	[link_time] [nvarchar](512) NULL,
	[tui] [int] NULL,
	[quxiao] [int] NULL,
 CONSTRAINT [PK_shop_users] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[shop_user_point_log]    Script Date: 08/29/2018 16:35:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[shop_user_point_log](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[user_name] [nvarchar](100) NULL,
	[value] [int] NULL,
	[remark] [nvarchar](500) NULL,
	[add_time] [datetime] NULL,
	[order_id] [int] NULL,
	[islock] [int] NULL,
	[bank] [nvarchar](512) NULL,
	[show] [int] NULL,
	[admin_id] [int] NULL,
	[admin_time] [datetime] NULL,
	[jieyu] [int] NULL,
 CONSTRAINT [PK_shop_user_point_log] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[shop_user_oauth]    Script Date: 08/29/2018 16:35:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[shop_user_oauth](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[user_name] [nvarchar](100) NULL,
	[oauth_name] [nvarchar](50) NOT NULL,
	[oauth_access_token] [nvarchar](500) NULL,
	[oauth_openid] [nvarchar](255) NULL,
	[add_time] [datetime] NULL,
 CONSTRAINT [PK_shop_user_oauth] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[shop_user_login_log]    Script Date: 08/29/2018 16:35:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[shop_user_login_log](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[user_name] [nvarchar](100) NULL,
	[remark] [nvarchar](255) NULL,
	[login_time] [datetime] NULL,
	[login_ip] [nvarchar](50) NULL,
 CONSTRAINT [PK_shop_user_login_log] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[shop_user_groups]    Script Date: 08/29/2018 16:35:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[shop_user_groups](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](100) NULL,
	[grade] [int] NULL,
	[upgrade_exp] [int] NULL,
	[amount] [decimal](9, 2) NULL,
	[point] [int] NULL,
	[discount] [int] NULL,
	[is_default] [tinyint] NULL,
	[is_upgrade] [tinyint] NULL,
	[is_lock] [tinyint] NULL,
 CONSTRAINT [PK_shop_user_groups] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[shop_user_group_price]    Script Date: 08/29/2018 16:35:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[shop_user_group_price](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[article_id] [int] NULL,
	[group_id] [int] NULL,
	[price] [decimal](9, 2) NULL,
 CONSTRAINT [PK_shop_user_group_price] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[shop_user_amount_log]    Script Date: 08/29/2018 16:35:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[shop_user_amount_log](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[user_name] [nvarchar](100) NULL,
	[payment_id] [int] NULL,
	[value] [decimal](9, 2) NULL,
	[remark] [nvarchar](500) NULL,
	[add_time] [datetime] NULL,
 CONSTRAINT [PK_shop_user_amount_log] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[shop_user_address]    Script Date: 08/29/2018 16:35:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[shop_user_address](
	[address_id] [int] IDENTITY(1,1) NOT NULL,
	[address_user] [int] NULL,
	[address_name] [nvarchar](128) NULL,
	[address_shenfen] [nvarchar](32) NULL,
	[address_city] [nvarchar](32) NULL,
	[address_qu] [nvarchar](32) NULL,
	[address_address] [nvarchar](256) NULL,
	[address_tel] [nvarchar](32) NULL,
	[address_mobile] [nvarchar](32) NULL,
	[address_email] [nvarchar](256) NULL,
	[address_zip] [nvarchar](32) NULL,
	[address_qita] [nvarchar](256) NULL,
	[address_lock] [int] NULL,
	[address_add_date] [datetime] NULL,
	[address_payment] [int] NULL,
	[show] [int] NULL,
	[wheresql] [nvarchar](32) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[shop_store]    Script Date: 08/29/2018 16:35:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[shop_store](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](100) NULL,
	[area_id] [int] NULL,
	[brand_id] [nvarchar](100) NULL,
	[address] [nvarchar](200) NULL,
	[tel] [nvarchar](30) NULL,
	[flagship] [tinyint] NULL,
	[coordinate] [nvarchar](50) NULL,
	[company] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[shop_slide]    Script Date: 08/29/2018 16:35:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[shop_slide](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](100) NULL,
	[link_url] [nvarchar](255) NULL,
	[img_url] [nvarchar](255) NULL,
	[brand_id] [int] NULL,
	[start_time] [datetime] NULL,
	[end_time] [datetime] NULL,
	[sort_id] [int] NULL,
	[company] [int] NULL,
 CONSTRAINT [PK_shop_slide] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[shop_sales]    Script Date: 08/29/2018 16:35:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[shop_sales](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](255) NULL,
	[sub_title] [nvarchar](100) NULL,
	[img_url] [nvarchar](255) NULL,
	[type] [nvarchar](50) NULL,
	[quantity] [int] NULL,
	[amount] [decimal](9, 2) NULL,
	[start_time] [datetime] NULL,
	[end_time] [datetime] NULL,
	[sort_id] [int] NULL,
	[status] [tinyint] NULL,
	[summary] [nvarchar](255) NULL,
	[content] [ntext] NULL,
	[company] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[shop_quan]    Script Date: 08/29/2018 16:35:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[shop_quan](
	[quan_id] [int] IDENTITY(1,1) NOT NULL,
	[quan_user] [int] NULL,
	[quan_username] [nvarchar](64) NULL,
	[quan_name] [nvarchar](256) NULL,
	[quan_title] [nvarchar](256) NULL,
	[quan_lock] [int] NULL,
	[quan_add_date] [datetime] NULL,
	[quan_begin_date] [datetime] NULL,
	[quan_end_date] [datetime] NULL,
	[quan_date] [datetime] NULL,
	[quan_code] [nvarchar](64) NULL,
	[quan_pwd] [nvarchar](64) NULL,
	[quan_where] [nvarchar](32) NULL,
	[quan_show] [int] NULL,
	[quan_type] [nvarchar](32) NULL,
	[quan_des] [ntext] NULL,
	[quan_sort] [int] NULL,
	[quan_pic] [nvarchar](128) NULL,
	[quan_admin] [int] NULL,
	[quan_adminname] [nvarchar](64) NULL,
	[quan_num] [money] NULL,
	[company] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[shop_payment]    Script Date: 08/29/2018 16:35:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[shop_payment](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](100) NULL,
	[img_url] [nvarchar](255) NULL,
	[remark] [nvarchar](500) NULL,
	[type] [tinyint] NULL,
	[poundage_type] [tinyint] NULL,
	[poundage_amount] [decimal](9, 2) NULL,
	[sort_id] [int] NULL,
	[is_lock] [tinyint] NULL,
	[api_path] [nvarchar](100) NULL,
	[company] [int] NULL,
 CONSTRAINT [PK_shop_payment] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[shop_orders]    Script Date: 08/29/2018 16:35:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[shop_orders](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[order_no] [nvarchar](100) NULL,
	[trade_no] [nvarchar](100) NULL,
	[user_id] [int] NULL,
	[user_name] [nvarchar](100) NULL,
	[payment_id] [int] NULL,
	[payment_fee] [decimal](9, 2) NULL,
	[payment_status] [tinyint] NULL,
	[payment_time] [datetime] NULL,
	[express_id] [int] NULL,
	[express_no] [nvarchar](100) NULL,
	[express_fee] [decimal](9, 2) NULL,
	[express_status] [tinyint] NULL,
	[express_time] [datetime] NULL,
	[accept_name] [nvarchar](50) NULL,
	[post_code] [nvarchar](20) NULL,
	[telphone] [nvarchar](30) NULL,
	[mobile] [nvarchar](20) NULL,
	[email] [nvarchar](100) NULL,
	[area] [nvarchar](100) NULL,
	[address] [nvarchar](500) NULL,
	[message] [nvarchar](500) NULL,
	[remark] [nvarchar](500) NULL,
	[is_invoice] [tinyint] NULL,
	[invoice_title] [varchar](1000) NULL,
	[invoice_taxes] [decimal](9, 2) NULL,
	[payable_amount] [decimal](9, 2) NULL,
	[real_amount] [decimal](9, 2) NULL,
	[order_amount] [decimal](9, 2) NULL,
	[point] [int] NULL,
	[status] [tinyint] NULL,
	[add_time] [datetime] NULL,
	[confirm_time] [datetime] NULL,
	[complete_time] [datetime] NULL,
	[company] [int] NULL,
	[zhe_code] [nvarchar](256) NULL,
	[zhe_moeny] [nvarchar](128) NULL,
	[zhe_else] [nvarchar](512) NULL,
	[tuid] [int] NULL,
	[artid] [int] NULL,
	[chuid] [int] NULL,
	[num] [int] NULL,
	[zhe] [decimal](18, 0) NULL,
	[user_add] [nvarchar](512) NULL,
	[order_pay] [nvarchar](512) NULL,
	[order_bao] [nvarchar](128) NULL,
	[order_pay_code] [nvarchar](100) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[shop_order_tui]    Script Date: 08/29/2018 16:35:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[shop_order_tui](
	[tui_id] [int] NOT NULL,
	[tui_order] [int] NULL,
	[tui_shop] [int] NULL,
	[tui_user] [int] NULL,
	[tui_state] [int] NULL,
	[tui_add_date] [datetime] NULL,
	[tui_type] [int] NULL,
	[tui_pic] [nvarchar](128) NULL,
	[tui_begin_date] [datetime] NULL,
	[tui_end_date] [datetime] NULL,
	[tui_content] [ntext] NULL,
	[tui_else] [nvarchar](512) NULL,
	[tui_admin] [int] NULL,
	[tui_name] [nvarchar](64) NULL,
	[tui_cart] [int] NULL,
	[tui_username] [nvarchar](64) NULL,
	[tui_lock] [int] NULL,
	[tui_revert] [ntext] NULL,
	[company] [int] NULL,
 CONSTRAINT [PK_shop_order_tui] PRIMARY KEY CLUSTERED 
(
	[tui_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[shop_order_goods]    Script Date: 08/29/2018 16:35:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[shop_order_goods](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[article_id] [int] NULL,
	[order_id] [int] NULL,
	[goods_no] [nvarchar](50) NULL,
	[goods_title] [nvarchar](100) NULL,
	[img_url] [nvarchar](255) NULL,
	[spec_text] [text] NULL,
	[goods_price] [decimal](9, 2) NULL,
	[real_price] [decimal](9, 2) NULL,
	[quantity] [int] NULL,
	[point] [int] NULL,
	[company] [int] NULL,
	[goods_code] [nvarchar](32) NULL,
	[goodsid] [int] NULL,
	[goods_where] [nvarchar](256) NULL,
	[goods_img] [nvarchar](256) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[shop_order_gift]    Script Date: 08/29/2018 16:35:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[shop_order_gift](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[order_id] [int] NULL,
	[gift_id] [int] NULL,
	[company] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[shop_order_comment]    Script Date: 08/29/2018 16:35:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[shop_order_comment](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[order_id] [int] NULL,
	[article_id] [int] NULL,
	[parent_id] [int] NULL,
	[user_id] [int] NULL,
	[user_name] [nvarchar](128) NULL,
	[user_ip] [nvarchar](128) NULL,
	[content] [ntext] NULL,
	[is_lock] [int] NULL,
	[add_time] [datetime] NULL,
	[is_reply] [int] NULL,
	[reply_content] [ntext] NULL,
	[order_code] [nvarchar](128) NULL,
	[order_name] [nvarchar](512) NULL,
	[title] [nvarchar](128) NULL,
	[type] [int] NULL,
	[reply_time] [datetime] NULL,
	[company] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[shop_news_feed]    Script Date: 08/29/2018 16:35:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[shop_news_feed](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[email] [nvarchar](50) NULL,
	[feed_time] [datetime] NULL,
 CONSTRAINT [PK_shop_news_feed] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[shop_navigation]    Script Date: 08/29/2018 16:35:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[shop_navigation](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[parent_id] [int] NULL,
	[channel_id] [int] NULL,
	[nav_type] [nvarchar](50) NULL,
	[name] [nvarchar](50) NULL,
	[title] [nvarchar](100) NULL,
	[sub_title] [nvarchar](100) NULL,
	[icon_url] [nvarchar](255) NULL,
	[link_url] [nvarchar](255) NULL,
	[sort_id] [int] NULL,
	[is_lock] [tinyint] NULL,
	[remark] [nvarchar](500) NULL,
	[action_type] [nvarchar](500) NULL,
	[is_sys] [tinyint] NULL,
	[company] [int] NULL,
 CONSTRAINT [PK_shop_navigation] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[shop_manager_role_value]    Script Date: 08/29/2018 16:35:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[shop_manager_role_value](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[role_id] [int] NULL,
	[nav_name] [nvarchar](100) NULL,
	[action_type] [nvarchar](50) NULL,
 CONSTRAINT [PK_shop_manager_role_value] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[shop_manager_role]    Script Date: 08/29/2018 16:35:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[shop_manager_role](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[role_name] [nvarchar](100) NULL,
	[role_type] [tinyint] NULL,
	[is_sys] [tinyint] NULL,
 CONSTRAINT [PK_shop_manager_role] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[shop_manager_log]    Script Date: 08/29/2018 16:35:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[shop_manager_log](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[user_name] [nvarchar](100) NULL,
	[action_type] [nvarchar](100) NULL,
	[remark] [nvarchar](255) NULL,
	[user_ip] [nvarchar](30) NULL,
	[add_time] [datetime] NULL,
 CONSTRAINT [PK_shop_manager_log] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[shop_manager]    Script Date: 08/29/2018 16:35:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[shop_manager](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[role_id] [int] NULL,
	[role_type] [int] NULL,
	[user_name] [nvarchar](100) NULL,
	[password] [nvarchar](100) NULL,
	[salt] [nvarchar](20) NULL,
	[real_name] [nvarchar](50) NULL,
	[telephone] [nvarchar](30) NULL,
	[email] [nvarchar](30) NULL,
	[is_lock] [int] NULL,
	[add_time] [datetime] NULL,
 CONSTRAINT [PK_shop_manager] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[shop_load_log]    Script Date: 08/29/2018 16:35:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[shop_load_log](
	[log_id] [int] NOT NULL,
	[log_add_date] [datetime] NULL,
	[log_shop] [int] NULL,
	[log_ip] [nvarchar](32) NULL,
	[log_num] [int] NULL,
	[log_where] [nvarchar](32) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[shop_ku_log]    Script Date: 08/29/2018 16:35:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[shop_ku_log](
	[log_id] [int] IDENTITY(1,1) NOT NULL,
	[log_shop] [int] NULL,
	[log_goods] [int] NULL,
	[log_add_date] [datetime] NULL,
	[log_num] [int] NULL,
	[log_old_num] [int] NULL,
	[log_new_num] [int] NULL,
	[log_where] [nvarchar](32) NULL,
	[log_user] [int] NULL,
	[log_name] [nvarchar](64) NULL,
	[log_title] [nvarchar](256) NULL,
	[company] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[shop_guige_list]    Script Date: 08/29/2018 16:35:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[shop_guige_list](
	[list_id] [int] IDENTITY(1,1) NOT NULL,
	[list_guige] [int] NULL,
	[list_title] [nvarchar](128) NULL,
	[list_pic] [nvarchar](128) NULL,
	[list_sort] [int] NULL,
	[list_web] [int] NULL,
	[list_content] [nvarchar](1024) NULL,
	[list_add_date] [datetime] NULL,
	[company] [int] NULL,
 CONSTRAINT [PK_shop_guige_list] PRIMARY KEY NONCLUSTERED 
(
	[list_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[shop_guige]    Script Date: 08/29/2018 16:35:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[shop_guige](
	[guige_id] [int] IDENTITY(1,1) NOT NULL,
	[guige_title] [nvarchar](128) NULL,
	[guige_content] [nvarchar](1024) NULL,
	[guige_sort] [int] NULL,
	[guige_add_date] [datetime] NULL,
	[guige_web] [int] NULL,
	[company] [int] NULL,
 CONSTRAINT [PK_shop_guige] PRIMARY KEY NONCLUSTERED 
(
	[guige_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[shop_goods_trace]    Script Date: 08/29/2018 16:35:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[shop_goods_trace](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[goods_id] [int] NULL,
	[goods_color] [nvarchar](20) NULL,
	[goods_size] [nvarchar](20) NULL,
	[user_name] [nvarchar](100) NULL,
	[add_time] [datetime] NULL,
	[company] [int] NULL,
 CONSTRAINT [PK_shop_goods_trace] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[shop_goods_sales]    Script Date: 08/29/2018 16:35:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[shop_goods_sales](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[main_id] [int] NOT NULL,
	[parent_id] [int] NOT NULL,
	[goods_id] [int] NOT NULL,
	[title] [nvarchar](100) NULL,
	[add_time] [datetime] NULL,
	[company] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[shop_goods_more_price]    Script Date: 08/29/2018 16:35:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[shop_goods_more_price](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[article_id] [int] NULL,
	[goods_id] [int] NULL,
	[goods_num] [int] NULL,
	[goods_lock] [int] NULL,
	[price] [decimal](9, 2) NULL,
	[more_chu] [int] NULL,
	[more_title] [nvarchar](128) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[shop_goods_group]    Script Date: 08/29/2018 16:35:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[shop_goods_group](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[main_id] [int] NOT NULL,
	[parent_id] [int] NOT NULL,
	[goods_id] [int] NOT NULL,
	[title] [nvarchar](100) NULL,
	[color] [nvarchar](20) NULL,
	[size] [nvarchar](20) NULL,
	[original_price] [decimal](9, 2) NULL,
	[new_price] [decimal](9, 2) NULL,
	[company] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[shop_goods]    Script Date: 08/29/2018 16:35:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[shop_goods](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[parent_id] [int] NOT NULL,
	[color] [nvarchar](56) NULL,
	[size] [nvarchar](56) NULL,
	[market_price] [decimal](9, 2) NULL,
	[sell_price] [decimal](9, 2) NULL,
	[stock_quantity] [int] NULL,
	[alert_quantity] [int] NULL,
	[goods_no] [nvarchar](50) NULL,
	[img_url] [nvarchar](100) NULL,
	[company] [int] NULL,
	[yu_lock] [int] NULL,
	[yu_day] [int] NULL,
	[yu_num] [int] NULL,
	[yu_date] [datetime] NULL,
	[guige] [nvarchar](128) NULL,
	[chang] [decimal](9, 2) NULL,
	[kuan] [decimal](9, 2) NULL,
	[gao] [decimal](9, 2) NULL,
	[zhong] [decimal](9, 2) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[shop_gift]    Script Date: 08/29/2018 16:35:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[shop_gift](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](255) NULL,
	[img_url] [nvarchar](255) NULL,
	[type] [nvarchar](50) NULL,
	[article_list] [nvarchar](255) NULL,
	[brand_id] [int] NULL,
	[quantity] [int] NULL,
	[amount] [decimal](9, 2) NULL,
	[sort_id] [int] NULL,
	[status] [tinyint] NULL,
	[left_quantity] [int] NULL,
	[content] [ntext] NULL,
	[add_time] [datetime] NULL,
	[company] [int] NULL,
	[gift_code] [nvarchar](100) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[shop_feedback]    Script Date: 08/29/2018 16:35:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[shop_feedback](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[type] [nvarchar](100) NULL,
	[title] [nvarchar](100) NULL,
	[content] [ntext] NULL,
	[user_name] [nvarchar](50) NULL,
	[user_tel] [nvarchar](30) NULL,
	[user_qq] [nvarchar](30) NULL,
	[user_email] [nvarchar](100) NULL,
	[add_time] [datetime] NOT NULL,
	[reply_content] [ntext] NULL,
	[reply_time] [datetime] NULL,
	[is_lock] [tinyint] NOT NULL,
	[company] [int] NULL,
	[beizhu] [ntext] NULL,
 CONSTRAINT [PK_shop_feedback] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[shop_ezship]    Script Date: 08/29/2018 16:35:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[shop_ezship](
	[id] [int] NOT NULL,
	[order_id] [int] NOT NULL,
	[order_code] [int] NULL,
	[st_cate] [nvarchar](100) NULL,
	[st_code] [nvarchar](100) NULL,
	[st_name] [nvarchar](100) NULL,
	[st_addr] [nvarchar](200) NULL,
	[st_tel] [nvarchar](100) NULL,
	[webtemp] [nvarchar](1024) NULL,
	[sn_id] [nvarchar](100) NULL,
	[state] [int] NULL,
	[add_time] [datetime] NULL,
	[qita] [nvarchar](1024) NULL,
	[company] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[shop_express]    Script Date: 08/29/2018 16:35:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[shop_express](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](100) NULL,
	[express_code] [nvarchar](100) NULL,
	[express_fee] [decimal](9, 2) NULL,
	[website] [nvarchar](255) NULL,
	[remark] [ntext] NULL,
	[sort_id] [int] NULL,
	[is_lock] [tinyint] NULL,
	[company] [int] NULL,
	[maxmoney] [money] NULL,
 CONSTRAINT [PK_shop_express] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[shop_chu_shop_goods]    Script Date: 08/29/2018 16:35:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[shop_chu_shop_goods](
	[chu_id] [int] IDENTITY(1,1) NOT NULL,
	[chu_shop] [int] NULL,
	[chu_goods] [int] NULL,
	[chu_add_date] [datetime] NULL,
	[chu_begin_date] [datetime] NULL,
	[chu_end_date] [datetime] NULL,
	[chu_where] [nvarchar](32) NULL,
	[chu_status] [int] NULL,
	[chu_type] [nvarchar](64) NULL,
	[chu_typeid] [int] NULL,
	[chu_title] [nvarchar](256) NULL,
	[chu_sort] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[shop_channel]    Script Date: 08/29/2018 16:35:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[shop_channel](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[site_id] [int] NULL,
	[name] [varchar](50) NULL,
	[title] [varchar](100) NULL,
	[is_albums] [tinyint] NULL,
	[is_attach] [tinyint] NULL,
	[is_spec] [tinyint] NULL,
	[sort_id] [int] NULL,
 CONSTRAINT [PK_shop_channel] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[shop_basic]    Script Date: 08/29/2018 16:35:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[shop_basic](
	[basic_id] [int] IDENTITY(1,1) NOT NULL,
	[basic_label] [nvarchar](128) NULL,
	[basic_value] [nvarchar](128) NULL,
	[basic_sort] [int] NULL,
	[basic_show] [int] NULL,
	[basic_type] [nvarchar](128) NULL,
	[basic_where] [nvarchar](128) NULL,
	[basic_pic] [nvarchar](128) NULL,
	[basic_money] [money] NULL,
	[basic_content] [ntext] NULL,
 CONSTRAINT [PK_shop_basic] PRIMARY KEY NONCLUSTERED 
(
	[basic_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[shop_article_tags_relation]    Script Date: 08/29/2018 16:35:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[shop_article_tags_relation](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[channel_id] [int] NULL,
	[article_id] [int] NULL,
	[tag_id] [int] NULL,
 CONSTRAINT [PK_DT_ARTICLE_TAGS_RELATION] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[shop_article_tags]    Script Date: 08/29/2018 16:35:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[shop_article_tags](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](100) NULL,
	[is_red] [tinyint] NULL,
	[sort_id] [int] NULL,
	[add_time] [datetime] NULL,
 CONSTRAINT [PK_DT_ARTICLE_TAGS] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[shop_article_product]    Script Date: 08/29/2018 16:35:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[shop_article_product](
	[article_id] [int] NOT NULL,
	[weiid] [char](16) NOT NULL,
	[goods_no] [nvarchar](100) NULL,
	[sub_title] [nvarchar](255) NULL,
	[stock_quantity] [int] NULL,
	[market_price] [decimal](9, 2) NULL,
	[sell_price] [decimal](9, 2) NULL,
	[point] [int] NULL,
	[seo_title] [nvarchar](255) NULL,
	[seo_keywords] [nvarchar](255) NULL,
	[seo_description] [nvarchar](255) NULL,
	[content] [ntext] NULL,
	[moshi] [nvarchar](16) NULL,
	[shuoming] [ntext] NULL,
	[zhuyi] [ntext] NULL,
	[guigemore] [ntext] NULL,
 CONSTRAINT [PK_news_article_content] PRIMARY KEY CLUSTERED 
(
	[article_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[shop_article_category]    Script Date: 08/29/2018 16:35:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[shop_article_category](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[channel_id] [int] NOT NULL,
	[title] [nvarchar](100) NULL,
	[call_index] [nvarchar](50) NULL,
	[parent_id] [int] NULL,
	[class_list] [nvarchar](500) NULL,
	[class_layer] [int] NULL,
	[sort_id] [int] NULL,
	[link_url] [nvarchar](255) NULL,
	[img_url] [nvarchar](255) NULL,
	[content] [ntext] NULL,
	[seo_title] [nvarchar](255) NULL,
	[seo_keywords] [nvarchar](255) NULL,
	[seo_description] [nvarchar](255) NULL,
	[company] [int] NULL,
 CONSTRAINT [PK_shop_article_category] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[shop_article_albums]    Script Date: 08/29/2018 16:35:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[shop_article_albums](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[article_id] [int] NULL,
	[thumb_path] [nvarchar](255) NULL,
	[original_path] [nvarchar](255) NULL,
	[remark] [nvarchar](500) NULL,
	[add_time] [datetime] NULL,
	[company] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[shop_article]    Script Date: 08/29/2018 16:35:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[shop_article](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[wid] [char](16) NULL,
	[channel_id] [int] NOT NULL,
	[channel_name] [nvarchar](16) NULL,
	[category_id] [int] NOT NULL,
	[call_index] [nvarchar](50) NULL,
	[title] [nvarchar](100) NULL,
	[link_url] [nvarchar](255) NULL,
	[img_url] [nvarchar](255) NULL,
	[tags] [nvarchar](500) NULL,
	[zhaiyao] [nvarchar](255) NULL,
	[sort_id] [int] NULL,
	[click] [int] NULL,
	[status] [tinyint] NULL,
	[is_msg] [tinyint] NULL,
	[is_tui] [int] NULL,
	[is_can] [int] NULL,
	[is_zhe] [int] NULL,
	[is_slide] [tinyint] NULL,
	[is_sys] [int] NULL,
	[user_name] [nvarchar](100) NULL,
	[add_time] [datetime] NULL,
	[update_time] [datetime] NULL,
	[company] [int] NULL,
	[wheresql] [nvarchar](16) NULL,
	[sales_id] [int] NULL,
	[brand_id] [int] NULL,
	[team_id] [int] NULL,
	[more_type] [nvarchar](512) NULL,
	[begin_time] [datetime] NULL,
	[end_time] [datetime] NULL,
	[color] [nvarchar](256) NULL,
	[guige] [nvarchar](256) NULL,
	[xia_date] [datetime] NULL,
 CONSTRAINT [PK_shop_article] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[shop_about]    Script Date: 08/29/2018 16:35:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[shop_about](
	[id] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[channel_id] [int] NOT NULL,
	[category_id] [int] NOT NULL,
	[call_index] [nvarchar](50) NULL,
	[title] [nvarchar](100) NULL,
	[link_url] [nvarchar](255) NULL,
	[img_url] [nvarchar](255) NULL,
	[seo_title] [nvarchar](255) NULL,
	[seo_keywords] [nvarchar](255) NULL,
	[seo_description] [nvarchar](255) NULL,
	[tags] [nvarchar](500) NULL,
	[zhaiyao] [nvarchar](255) NULL,
	[content] [ntext] NULL,
	[sort_id] [int] NULL,
	[click] [int] NULL,
	[status] [tinyint] NULL,
	[is_msg] [tinyint] NULL,
	[is_top] [tinyint] NULL,
	[is_red] [tinyint] NULL,
	[is_hot] [tinyint] NULL,
	[is_slide] [tinyint] NULL,
	[is_sys] [tinyint] NULL,
	[user_name] [nvarchar](100) NULL,
	[add_time] [datetime] NULL,
	[update_time] [datetime] NULL,
	[company] [int] NULL,
	[site] [int] NULL,
 CONSTRAINT [PK_shop_about] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[view_goods_sales]    Script Date: 08/29/2018 16:35:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[view_goods_sales]
as
select g.*,s.title as stitle,s.company as scompany from shop_sales s join shop_goods_sales g on s.id=g.main_id
GO
/****** Object:  View [dbo].[view_goods]    Script Date: 08/29/2018 16:35:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[view_goods]
as
select a.more_type, a.xia_date, a.click, a.sort_id, a.status,a.add_time, a.brand_id, g.*,a.title,a.category_id,a.wheresql,a.id as aid,a.sales_id from shop_article a join shop_goods g on a.id=g.parent_id
GO
/****** Object:  View [dbo].[view_article_product]    Script Date: 08/29/2018 16:35:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  view [dbo].[view_article_product]
as
select * from  shop_article a join  shop_article_product c on a.id=c.article_id
GO
/****** Object:  View [dbo].[view_order_point]    Script Date: 08/29/2018 16:35:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[view_order_point]
as
select p.*,o.order_amount,o.order_no,o.point,o.add_time as addtime from  shop_user_point_log p left join  shop_orders o on p.order_id=o.id
GO
/****** Object:  View [dbo].[view_order_goods]    Script Date: 08/29/2018 16:35:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[view_order_goods]
as
select o.*,g.article_id,g.goods_no,g.goods_code,g.goods_title,g.real_price,g.quantity from shop_orders o join shop_order_goods g on o.id=g.order_id
GO
/****** Object:  View [dbo].[view_order_gift]    Script Date: 08/29/2018 16:35:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[view_order_gift] 
as
select g.*,o.order_id,o.company as ocompany from shop_gift g join shop_order_gift o on g.id=o.gift_id
GO
/****** Object:  View [dbo].[view_order]    Script Date: 08/29/2018 16:35:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[view_order] 
as
select g.*,o.status,o.add_time,o.order_no,o.user_id,o.complete_time,o.user_name,o.accept_name from shop_orders o join shop_order_goods g on o.id=g.order_id
GO
/****** Object:  View [dbo].[view_jiajia]    Script Date: 08/29/2018 16:35:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[view_jiajia]
as
select a.*,g.id as gid from shop_article a join shop_goods g on a.id=g.parent_id where wheresql='jiajia'
GO
/****** Object:  View [dbo].[view_user_group_price]    Script Date: 08/29/2018 16:35:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[view_user_group_price]
as
select g.*,p.id as pid,p.group_id,p.price from view_goods g join shop_user_group_price p on g.id=p.article_id
GO
/****** Object:  View [dbo].[view_goods_trace]    Script Date: 08/29/2018 16:35:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[view_goods_trace]
as
select a.*,t.user_name as username,t.add_time as addtime,t.goods_id,t.goods_color,t.id as tid from shop_goods_trace t join view_article_product a on t.goods_id=a.id
GO
/****** Object:  Default [DF__shop_abou__chann__07C12930]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_about] ADD  CONSTRAINT [DF__shop_abou__chann__07C12930]  DEFAULT ((0)) FOR [channel_id]
GO
/****** Object:  Default [DF__shop_abou__categ__08B54D69]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_about] ADD  CONSTRAINT [DF__shop_abou__categ__08B54D69]  DEFAULT ((0)) FOR [category_id]
GO
/****** Object:  Default [DF__shop_abou__call___09A971A2]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_about] ADD  CONSTRAINT [DF__shop_abou__call___09A971A2]  DEFAULT ('') FOR [call_index]
GO
/****** Object:  Default [DF__shop_abou__link___0A9D95DB]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_about] ADD  CONSTRAINT [DF__shop_abou__link___0A9D95DB]  DEFAULT ('') FOR [link_url]
GO
/****** Object:  Default [DF__shop_abou__img_u__0B91BA14]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_about] ADD  CONSTRAINT [DF__shop_abou__img_u__0B91BA14]  DEFAULT ('') FOR [img_url]
GO
/****** Object:  Default [DF__shop_abou__seo_t__0C85DE4D]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_about] ADD  CONSTRAINT [DF__shop_abou__seo_t__0C85DE4D]  DEFAULT ('') FOR [seo_title]
GO
/****** Object:  Default [DF__shop_abou__seo_k__0D7A0286]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_about] ADD  CONSTRAINT [DF__shop_abou__seo_k__0D7A0286]  DEFAULT ('') FOR [seo_keywords]
GO
/****** Object:  Default [DF__shop_abou__seo_d__0E6E26BF]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_about] ADD  CONSTRAINT [DF__shop_abou__seo_d__0E6E26BF]  DEFAULT ('') FOR [seo_description]
GO
/****** Object:  Default [DF__shop_abou__zhaiy__0F624AF8]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_about] ADD  CONSTRAINT [DF__shop_abou__zhaiy__0F624AF8]  DEFAULT ('') FOR [zhaiyao]
GO
/****** Object:  Default [DF__shop_abou__sort___10566F31]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_about] ADD  CONSTRAINT [DF__shop_abou__sort___10566F31]  DEFAULT ((99)) FOR [sort_id]
GO
/****** Object:  Default [DF__shop_abou__click__114A936A]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_about] ADD  CONSTRAINT [DF__shop_abou__click__114A936A]  DEFAULT ((0)) FOR [click]
GO
/****** Object:  Default [DF__shop_abou__statu__123EB7A3]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_about] ADD  CONSTRAINT [DF__shop_abou__statu__123EB7A3]  DEFAULT ((0)) FOR [status]
GO
/****** Object:  Default [DF__shop_abou__is_ms__1332DBDC]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_about] ADD  CONSTRAINT [DF__shop_abou__is_ms__1332DBDC]  DEFAULT ((0)) FOR [is_msg]
GO
/****** Object:  Default [DF__shop_abou__is_to__14270015]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_about] ADD  CONSTRAINT [DF__shop_abou__is_to__14270015]  DEFAULT ((0)) FOR [is_top]
GO
/****** Object:  Default [DF__shop_abou__is_re__151B244E]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_about] ADD  CONSTRAINT [DF__shop_abou__is_re__151B244E]  DEFAULT ((0)) FOR [is_red]
GO
/****** Object:  Default [DF__shop_abou__is_ho__160F4887]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_about] ADD  CONSTRAINT [DF__shop_abou__is_ho__160F4887]  DEFAULT ((0)) FOR [is_hot]
GO
/****** Object:  Default [DF__shop_abou__is_sl__17036CC0]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_about] ADD  CONSTRAINT [DF__shop_abou__is_sl__17036CC0]  DEFAULT ((0)) FOR [is_slide]
GO
/****** Object:  Default [DF__shop_abou__is_sy__17F790F9]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_about] ADD  CONSTRAINT [DF__shop_abou__is_sy__17F790F9]  DEFAULT ((0)) FOR [is_sys]
GO
/****** Object:  Default [DF__shop_abou__add_t__18EBB532]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_about] ADD  CONSTRAINT [DF__shop_abou__add_t__18EBB532]  DEFAULT (getdate()) FOR [add_time]
GO
/****** Object:  Default [DF__shop_arti__chann__75A278F5]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_article] ADD  CONSTRAINT [DF__shop_arti__chann__75A278F5]  DEFAULT ((0)) FOR [channel_id]
GO
/****** Object:  Default [DF__shop_arti__categ__76969D2E]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_article] ADD  CONSTRAINT [DF__shop_arti__categ__76969D2E]  DEFAULT ((0)) FOR [category_id]
GO
/****** Object:  Default [DF__shop_arti__call___778AC167]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_article] ADD  CONSTRAINT [DF__shop_arti__call___778AC167]  DEFAULT ('') FOR [call_index]
GO
/****** Object:  Default [DF__shop_arti__link___787EE5A0]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_article] ADD  CONSTRAINT [DF__shop_arti__link___787EE5A0]  DEFAULT ('') FOR [link_url]
GO
/****** Object:  Default [DF__shop_arti__img_u__797309D9]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_article] ADD  CONSTRAINT [DF__shop_arti__img_u__797309D9]  DEFAULT ('') FOR [img_url]
GO
/****** Object:  Default [DF__shop_arti__zhaiy__7D439ABD]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_article] ADD  CONSTRAINT [DF__shop_arti__zhaiy__7D439ABD]  DEFAULT ('') FOR [zhaiyao]
GO
/****** Object:  Default [DF__shop_arti__sort___7E37BEF6]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_article] ADD  CONSTRAINT [DF__shop_arti__sort___7E37BEF6]  DEFAULT ((99)) FOR [sort_id]
GO
/****** Object:  Default [DF__shop_arti__click__7F2BE32F]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_article] ADD  CONSTRAINT [DF__shop_arti__click__7F2BE32F]  DEFAULT ((0)) FOR [click]
GO
/****** Object:  Default [DF__shop_arti__statu__00200768]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_article] ADD  CONSTRAINT [DF__shop_arti__statu__00200768]  DEFAULT ((0)) FOR [status]
GO
/****** Object:  Default [DF__shop_arti__is_ms__01142BA1]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_article] ADD  CONSTRAINT [DF__shop_arti__is_ms__01142BA1]  DEFAULT ((0)) FOR [is_msg]
GO
/****** Object:  Default [DF__shop_arti__is_to__02084FDA]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_article] ADD  CONSTRAINT [DF__shop_arti__is_to__02084FDA]  DEFAULT ((0)) FOR [is_tui]
GO
/****** Object:  Default [DF__shop_arti__is_re__02FC7413]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_article] ADD  CONSTRAINT [DF__shop_arti__is_re__02FC7413]  DEFAULT ((0)) FOR [is_can]
GO
/****** Object:  Default [DF__shop_arti__is_ho__03F0984C]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_article] ADD  CONSTRAINT [DF__shop_arti__is_ho__03F0984C]  DEFAULT ((0)) FOR [is_zhe]
GO
/****** Object:  Default [DF__shop_arti__is_sl__04E4BC85]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_article] ADD  CONSTRAINT [DF__shop_arti__is_sl__04E4BC85]  DEFAULT ((0)) FOR [is_slide]
GO
/****** Object:  Default [DF__shop_arti__is_sy__05D8E0BE]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_article] ADD  CONSTRAINT [DF__shop_arti__is_sy__05D8E0BE]  DEFAULT ((0)) FOR [is_sys]
GO
/****** Object:  Default [DF__shop_arti__add_t__06CD04F7]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_article] ADD  CONSTRAINT [DF__shop_arti__add_t__06CD04F7]  DEFAULT (getdate()) FOR [add_time]
GO
/****** Object:  Default [DF__shop_arti__sales__07C12930]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_article] ADD  CONSTRAINT [DF__shop_arti__sales__07C12930]  DEFAULT ((0)) FOR [sales_id]
GO
/****** Object:  Default [DF__shop_arti__brand__08B54D69]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_article] ADD  CONSTRAINT [DF__shop_arti__brand__08B54D69]  DEFAULT ((0)) FOR [brand_id]
GO
/****** Object:  Default [DF__shop_arti__team___09A971A2]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_article] ADD  CONSTRAINT [DF__shop_arti__team___09A971A2]  DEFAULT ((0)) FOR [team_id]
GO
/****** Object:  Default [DF__shop_arti__artic__2BFE89A6]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_article_albums] ADD  DEFAULT ((0)) FOR [article_id]
GO
/****** Object:  Default [DF__shop_arti__thumb__2CF2ADDF]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_article_albums] ADD  DEFAULT ('') FOR [thumb_path]
GO
/****** Object:  Default [DF__shop_arti__origi__2DE6D218]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_article_albums] ADD  DEFAULT ('') FOR [original_path]
GO
/****** Object:  Default [DF__shop_arti__remar__2EDAF651]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_article_albums] ADD  DEFAULT ('') FOR [remark]
GO
/****** Object:  Default [DF__shop_arti__add_t__2FCF1A8A]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_article_albums] ADD  DEFAULT (getdate()) FOR [add_time]
GO
/****** Object:  Default [DF__shop_arti__call___498EEC8D]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_article_category] ADD  DEFAULT ('') FOR [call_index]
GO
/****** Object:  Default [DF__shop_arti__paren__4A8310C6]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_article_category] ADD  DEFAULT ((0)) FOR [parent_id]
GO
/****** Object:  Default [DF__shop_arti__class__4B7734FF]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_article_category] ADD  DEFAULT ((0)) FOR [class_layer]
GO
/****** Object:  Default [DF__shop_arti__sort___4C6B5938]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_article_category] ADD  DEFAULT ((99)) FOR [sort_id]
GO
/****** Object:  Default [DF__shop_arti__link___4D5F7D71]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_article_category] ADD  DEFAULT ('') FOR [link_url]
GO
/****** Object:  Default [DF__shop_arti__img_u__4E53A1AA]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_article_category] ADD  DEFAULT ('') FOR [img_url]
GO
/****** Object:  Default [DF__shop_arti__seo_t__4F47C5E3]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_article_category] ADD  DEFAULT ('') FOR [seo_title]
GO
/****** Object:  Default [DF__shop_arti__seo_k__503BEA1C]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_article_category] ADD  DEFAULT ('') FOR [seo_keywords]
GO
/****** Object:  Default [DF__shop_arti__seo_d__51300E55]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_article_category] ADD  DEFAULT ('') FOR [seo_description]
GO
/****** Object:  Default [DF__shop_chann__name__59C55456]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_channel] ADD  DEFAULT ('') FOR [name]
GO
/****** Object:  Default [DF__shop_chan__title__5AB9788F]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_channel] ADD  DEFAULT ('') FOR [title]
GO
/****** Object:  Default [DF__shop_chan__is_al__5BAD9CC8]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_channel] ADD  DEFAULT ((0)) FOR [is_albums]
GO
/****** Object:  Default [DF__shop_chan__is_at__5CA1C101]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_channel] ADD  DEFAULT ((0)) FOR [is_attach]
GO
/****** Object:  Default [DF__shop_chan__is_sp__5D95E53A]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_channel] ADD  DEFAULT ((0)) FOR [is_spec]
GO
/****** Object:  Default [DF__shop_chan__sort___5E8A0973]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_channel] ADD  DEFAULT ((99)) FOR [sort_id]
GO
/****** Object:  Default [DF__shop_expr__expre__18B6AB08]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_express] ADD  DEFAULT ('') FOR [express_code]
GO
/****** Object:  Default [DF__shop_expr__expre__19AACF41]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_express] ADD  DEFAULT ((0)) FOR [express_fee]
GO
/****** Object:  Default [DF__shop_expr__websi__1A9EF37A]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_express] ADD  DEFAULT ('') FOR [website]
GO
/****** Object:  Default [DF__shop_expr__remar__1B9317B3]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_express] ADD  DEFAULT ('') FOR [remark]
GO
/****** Object:  Default [DF__shop_expr__sort___1C873BEC]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_express] ADD  DEFAULT ((99)) FOR [sort_id]
GO
/****** Object:  Default [DF__shop_expr__is_lo__1D7B6025]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_express] ADD  DEFAULT ((0)) FOR [is_lock]
GO
/****** Object:  Default [DF__shop_ezsh__order__1E6F845E]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_ezship] ADD  DEFAULT ((2)) FOR [order_code]
GO
/****** Object:  Default [DF__shop_ezsh__st_na__1F63A897]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_ezship] ADD  DEFAULT ('') FOR [st_name]
GO
/****** Object:  Default [DF__shop_ezsh__st_ad__2057CCD0]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_ezship] ADD  DEFAULT ('') FOR [st_addr]
GO
/****** Object:  Default [DF__shop_ezsh__st_te__214BF109]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_ezship] ADD  DEFAULT ('') FOR [st_tel]
GO
/****** Object:  Default [DF__shop_ezsh__webte__22401542]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_ezship] ADD  DEFAULT ('') FOR [webtemp]
GO
/****** Object:  Default [DF__shop_ezsh__sn_id__2334397B]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_ezship] ADD  DEFAULT ('') FOR [sn_id]
GO
/****** Object:  Default [DF__shop_ezshi__qita__24285DB4]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_ezship] ADD  DEFAULT ('') FOR [qita]
GO
/****** Object:  Default [DF__shop_feed__add_t__251C81ED]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_feedback] ADD  DEFAULT (getdate()) FOR [add_time]
GO
/****** Object:  Default [DF__shop_feed__reply__2610A626]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_feedback] ADD  DEFAULT ('') FOR [reply_content]
GO
/****** Object:  Default [DF__shop_feed__is_lo__2704CA5F]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_feedback] ADD  DEFAULT ((0)) FOR [is_lock]
GO
/****** Object:  Default [DF__shop_gift__title__27F8EE98]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_gift] ADD  CONSTRAINT [DF__shop_gift__title__27F8EE98]  DEFAULT ('') FOR [title]
GO
/****** Object:  Default [DF__shop_gift__img_u__28ED12D1]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_gift] ADD  CONSTRAINT [DF__shop_gift__img_u__28ED12D1]  DEFAULT ('') FOR [img_url]
GO
/****** Object:  Default [DF__shop_gift__type__29E1370A]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_gift] ADD  CONSTRAINT [DF__shop_gift__type__29E1370A]  DEFAULT ('') FOR [type]
GO
/****** Object:  Default [DF__shop_gift__artic__2AD55B43]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_gift] ADD  CONSTRAINT [DF__shop_gift__artic__2AD55B43]  DEFAULT ('') FOR [article_list]
GO
/****** Object:  Default [DF__shop_gift__brand__2BC97F7C]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_gift] ADD  CONSTRAINT [DF__shop_gift__brand__2BC97F7C]  DEFAULT ((0)) FOR [brand_id]
GO
/****** Object:  Default [DF__shop_gift__quant__2CBDA3B5]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_gift] ADD  CONSTRAINT [DF__shop_gift__quant__2CBDA3B5]  DEFAULT ((0)) FOR [quantity]
GO
/****** Object:  Default [DF__shop_gift__amoun__2DB1C7EE]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_gift] ADD  CONSTRAINT [DF__shop_gift__amoun__2DB1C7EE]  DEFAULT ((0)) FOR [amount]
GO
/****** Object:  Default [DF__shop_gift__sort___2EA5EC27]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_gift] ADD  CONSTRAINT [DF__shop_gift__sort___2EA5EC27]  DEFAULT ((99)) FOR [sort_id]
GO
/****** Object:  Default [DF__shop_gift__statu__2F9A1060]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_gift] ADD  CONSTRAINT [DF__shop_gift__statu__2F9A1060]  DEFAULT ((0)) FOR [status]
GO
/****** Object:  Default [DF__shop_gift__left___308E3499]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_gift] ADD  CONSTRAINT [DF__shop_gift__left___308E3499]  DEFAULT ((0)) FOR [left_quantity]
GO
/****** Object:  Default [DF__shop_gift__conte__318258D2]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_gift] ADD  CONSTRAINT [DF__shop_gift__conte__318258D2]  DEFAULT ('') FOR [content]
GO
/****** Object:  Default [DF__shop_gift__add_t__32767D0B]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_gift] ADD  CONSTRAINT [DF__shop_gift__add_t__32767D0B]  DEFAULT (getdate()) FOR [add_time]
GO
/****** Object:  Default [DF__shop_good__paren__336AA144]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_goods] ADD  CONSTRAINT [DF__shop_good__paren__336AA144]  DEFAULT ((0)) FOR [parent_id]
GO
/****** Object:  Default [DF__shop_good__color__345EC57D]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_goods] ADD  CONSTRAINT [DF__shop_good__color__345EC57D]  DEFAULT ('') FOR [color]
GO
/****** Object:  Default [DF__shop_goods__size__3552E9B6]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_goods] ADD  CONSTRAINT [DF__shop_goods__size__3552E9B6]  DEFAULT ('') FOR [size]
GO
/****** Object:  Default [DF__shop_good__marke__36470DEF]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_goods] ADD  CONSTRAINT [DF__shop_good__marke__36470DEF]  DEFAULT ((0)) FOR [market_price]
GO
/****** Object:  Default [DF__shop_good__sell___373B3228]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_goods] ADD  CONSTRAINT [DF__shop_good__sell___373B3228]  DEFAULT ((0)) FOR [sell_price]
GO
/****** Object:  Default [DF__shop_good__stock__382F5661]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_goods] ADD  CONSTRAINT [DF__shop_good__stock__382F5661]  DEFAULT ((0)) FOR [stock_quantity]
GO
/****** Object:  Default [DF__shop_good__alert__39237A9A]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_goods] ADD  CONSTRAINT [DF__shop_good__alert__39237A9A]  DEFAULT ((0)) FOR [alert_quantity]
GO
/****** Object:  Default [DF__shop_good__goods__3A179ED3]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_goods] ADD  CONSTRAINT [DF__shop_good__goods__3A179ED3]  DEFAULT ('') FOR [goods_no]
GO
/****** Object:  Default [DF__shop_good__img_u__3B0BC30C]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_goods] ADD  CONSTRAINT [DF__shop_good__img_u__3B0BC30C]  DEFAULT ('') FOR [img_url]
GO
/****** Object:  Default [DF__shop_good__main___40C49C62]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_goods_group] ADD  DEFAULT ((0)) FOR [main_id]
GO
/****** Object:  Default [DF__shop_good__paren__41B8C09B]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_goods_group] ADD  DEFAULT ((0)) FOR [parent_id]
GO
/****** Object:  Default [DF__shop_good__goods__42ACE4D4]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_goods_group] ADD  DEFAULT ((0)) FOR [goods_id]
GO
/****** Object:  Default [DF__shop_good__title__43A1090D]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_goods_group] ADD  DEFAULT ('') FOR [title]
GO
/****** Object:  Default [DF__shop_good__color__44952D46]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_goods_group] ADD  DEFAULT ('') FOR [color]
GO
/****** Object:  Default [DF__shop_goods__size__4589517F]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_goods_group] ADD  DEFAULT ('') FOR [size]
GO
/****** Object:  Default [DF__shop_good__origi__467D75B8]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_goods_group] ADD  DEFAULT ((0)) FOR [original_price]
GO
/****** Object:  Default [DF__shop_good__new_p__477199F1]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_goods_group] ADD  DEFAULT ((0)) FOR [new_price]
GO
/****** Object:  Default [DF__shop_good__artic__4865BE2A]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_goods_more_price] ADD  DEFAULT ((0)) FOR [article_id]
GO
/****** Object:  Default [DF__shop_good__goods__4959E263]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_goods_more_price] ADD  DEFAULT ((0)) FOR [goods_id]
GO
/****** Object:  Default [DF__shop_good__goods__4A4E069C]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_goods_more_price] ADD  DEFAULT ((0)) FOR [goods_num]
GO
/****** Object:  Default [DF__shop_good__goods__4B422AD5]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_goods_more_price] ADD  DEFAULT ((0)) FOR [goods_lock]
GO
/****** Object:  Default [DF__shop_good__price__4C364F0E]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_goods_more_price] ADD  DEFAULT ((0)) FOR [price]
GO
/****** Object:  Default [DF__shop_good__main___4D2A7347]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_goods_sales] ADD  DEFAULT ((0)) FOR [main_id]
GO
/****** Object:  Default [DF__shop_good__paren__4E1E9780]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_goods_sales] ADD  DEFAULT ((0)) FOR [parent_id]
GO
/****** Object:  Default [DF__shop_good__goods__4F12BBB9]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_goods_sales] ADD  DEFAULT ((0)) FOR [goods_id]
GO
/****** Object:  Default [DF__shop_good__title__5006DFF2]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_goods_sales] ADD  DEFAULT ('') FOR [title]
GO
/****** Object:  Default [DF__shop_good__add_t__55BFB948]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_goods_trace] ADD  DEFAULT (getdate()) FOR [add_time]
GO
/****** Object:  Default [DF__shop_mana__role___5B78929E]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_manager] ADD  DEFAULT ((2)) FOR [role_type]
GO
/****** Object:  Default [DF__shop_mana__real___5C6CB6D7]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_manager] ADD  DEFAULT ('') FOR [real_name]
GO
/****** Object:  Default [DF__shop_mana__telep__5D60DB10]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_manager] ADD  DEFAULT ('') FOR [telephone]
GO
/****** Object:  Default [DF__shop_mana__email__5E54FF49]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_manager] ADD  DEFAULT ('') FOR [email]
GO
/****** Object:  Default [DF__shop_mana__is_lo__5F492382]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_manager] ADD  DEFAULT ((0)) FOR [is_lock]
GO
/****** Object:  Default [DF__shop_mana__add_t__603D47BB]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_manager] ADD  DEFAULT (getdate()) FOR [add_time]
GO
/****** Object:  Default [DF__shop_mana__add_t__61316BF4]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_manager_log] ADD  DEFAULT (getdate()) FOR [add_time]
GO
/****** Object:  Default [DF__shop_mana__is_sy__6225902D]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_manager_role] ADD  DEFAULT ((0)) FOR [is_sys]
GO
/****** Object:  Default [DF__shop_news__feed___6319B466]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_news_feed] ADD  DEFAULT (getdate()) FOR [feed_time]
GO
/****** Object:  Default [DF__shop_orde__order__640DD89F]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_order_gift] ADD  DEFAULT ((0)) FOR [order_id]
GO
/****** Object:  Default [DF__shop_orde__gift___6501FCD8]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_order_gift] ADD  DEFAULT ((0)) FOR [gift_id]
GO
/****** Object:  Default [DF__shop_orde__goods__65F62111]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_order_goods] ADD  DEFAULT ((0)) FOR [goods_price]
GO
/****** Object:  Default [DF__shop_orde__real___66EA454A]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_order_goods] ADD  DEFAULT ((0)) FOR [real_price]
GO
/****** Object:  Default [DF__shop_orde__quant__67DE6983]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_order_goods] ADD  DEFAULT ((0)) FOR [quantity]
GO
/****** Object:  Default [DF__shop_orde__point__68D28DBC]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_order_goods] ADD  DEFAULT ((0)) FOR [point]
GO
/****** Object:  Default [DF__shop_orde__order__69C6B1F5]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_orders] ADD  CONSTRAINT [DF__shop_orde__order__69C6B1F5]  DEFAULT ('') FOR [order_no]
GO
/****** Object:  Default [DF__shop_orde__trade__6ABAD62E]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_orders] ADD  CONSTRAINT [DF__shop_orde__trade__6ABAD62E]  DEFAULT ('') FOR [trade_no]
GO
/****** Object:  Default [DF__shop_orde__user___6BAEFA67]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_orders] ADD  CONSTRAINT [DF__shop_orde__user___6BAEFA67]  DEFAULT ((0)) FOR [user_id]
GO
/****** Object:  Default [DF__shop_orde__user___6CA31EA0]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_orders] ADD  CONSTRAINT [DF__shop_orde__user___6CA31EA0]  DEFAULT ('') FOR [user_name]
GO
/****** Object:  Default [DF__shop_orde__payme__6D9742D9]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_orders] ADD  CONSTRAINT [DF__shop_orde__payme__6D9742D9]  DEFAULT ((0)) FOR [payment_id]
GO
/****** Object:  Default [DF__shop_orde__payme__6E8B6712]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_orders] ADD  CONSTRAINT [DF__shop_orde__payme__6E8B6712]  DEFAULT ((0)) FOR [payment_fee]
GO
/****** Object:  Default [DF__shop_orde__payme__6F7F8B4B]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_orders] ADD  CONSTRAINT [DF__shop_orde__payme__6F7F8B4B]  DEFAULT ((0)) FOR [payment_status]
GO
/****** Object:  Default [DF__shop_orde__expre__7073AF84]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_orders] ADD  CONSTRAINT [DF__shop_orde__expre__7073AF84]  DEFAULT ((0)) FOR [express_id]
GO
/****** Object:  Default [DF__shop_orde__expre__7167D3BD]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_orders] ADD  CONSTRAINT [DF__shop_orde__expre__7167D3BD]  DEFAULT ('') FOR [express_no]
GO
/****** Object:  Default [DF__shop_orde__expre__725BF7F6]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_orders] ADD  CONSTRAINT [DF__shop_orde__expre__725BF7F6]  DEFAULT ((0)) FOR [express_fee]
GO
/****** Object:  Default [DF__shop_orde__expre__73501C2F]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_orders] ADD  CONSTRAINT [DF__shop_orde__expre__73501C2F]  DEFAULT ((0)) FOR [express_status]
GO
/****** Object:  Default [DF__shop_orde__accep__74444068]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_orders] ADD  CONSTRAINT [DF__shop_orde__accep__74444068]  DEFAULT ('') FOR [accept_name]
GO
/****** Object:  Default [DF__shop_orde__post___753864A1]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_orders] ADD  CONSTRAINT [DF__shop_orde__post___753864A1]  DEFAULT ('') FOR [post_code]
GO
/****** Object:  Default [DF__shop_orde__telph__762C88DA]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_orders] ADD  CONSTRAINT [DF__shop_orde__telph__762C88DA]  DEFAULT ('') FOR [telphone]
GO
/****** Object:  Default [DF__shop_orde__mobil__7720AD13]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_orders] ADD  CONSTRAINT [DF__shop_orde__mobil__7720AD13]  DEFAULT ('') FOR [mobile]
GO
/****** Object:  Default [DF__shop_orde__email__7814D14C]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_orders] ADD  CONSTRAINT [DF__shop_orde__email__7814D14C]  DEFAULT ('') FOR [email]
GO
/****** Object:  Default [DF__shop_order__area__7908F585]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_orders] ADD  CONSTRAINT [DF__shop_order__area__7908F585]  DEFAULT ('') FOR [area]
GO
/****** Object:  Default [DF__shop_orde__addre__79FD19BE]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_orders] ADD  CONSTRAINT [DF__shop_orde__addre__79FD19BE]  DEFAULT ('') FOR [address]
GO
/****** Object:  Default [DF__shop_orde__messa__7AF13DF7]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_orders] ADD  CONSTRAINT [DF__shop_orde__messa__7AF13DF7]  DEFAULT ('') FOR [message]
GO
/****** Object:  Default [DF__shop_orde__remar__7BE56230]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_orders] ADD  CONSTRAINT [DF__shop_orde__remar__7BE56230]  DEFAULT ('') FOR [remark]
GO
/****** Object:  Default [DF__shop_orde__is_in__7CD98669]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_orders] ADD  CONSTRAINT [DF__shop_orde__is_in__7CD98669]  DEFAULT ((0)) FOR [is_invoice]
GO
/****** Object:  Default [DF__shop_orde__invoi__7DCDAAA2]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_orders] ADD  CONSTRAINT [DF__shop_orde__invoi__7DCDAAA2]  DEFAULT ((0)) FOR [invoice_taxes]
GO
/****** Object:  Default [DF__shop_orde__payab__7EC1CEDB]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_orders] ADD  CONSTRAINT [DF__shop_orde__payab__7EC1CEDB]  DEFAULT ((0)) FOR [payable_amount]
GO
/****** Object:  Default [DF__shop_orde__real___7FB5F314]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_orders] ADD  CONSTRAINT [DF__shop_orde__real___7FB5F314]  DEFAULT ((0)) FOR [real_amount]
GO
/****** Object:  Default [DF__shop_orde__order__00AA174D]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_orders] ADD  CONSTRAINT [DF__shop_orde__order__00AA174D]  DEFAULT ((0)) FOR [order_amount]
GO
/****** Object:  Default [DF__shop_orde__point__019E3B86]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_orders] ADD  CONSTRAINT [DF__shop_orde__point__019E3B86]  DEFAULT ((0)) FOR [point]
GO
/****** Object:  Default [DF__shop_orde__statu__02925FBF]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_orders] ADD  CONSTRAINT [DF__shop_orde__statu__02925FBF]  DEFAULT ((1)) FOR [status]
GO
/****** Object:  Default [DF__shop_orde__add_t__038683F8]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_orders] ADD  CONSTRAINT [DF__shop_orde__add_t__038683F8]  DEFAULT (getdate()) FOR [add_time]
GO
/****** Object:  Default [DF__shop_paym__img_u__047AA831]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_payment] ADD  DEFAULT ('') FOR [img_url]
GO
/****** Object:  Default [DF__shop_payme__type__056ECC6A]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_payment] ADD  DEFAULT ((1)) FOR [type]
GO
/****** Object:  Default [DF__shop_paym__pound__0662F0A3]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_payment] ADD  DEFAULT ((1)) FOR [poundage_type]
GO
/****** Object:  Default [DF__shop_paym__pound__075714DC]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_payment] ADD  DEFAULT ((0)) FOR [poundage_amount]
GO
/****** Object:  Default [DF__shop_paym__sort___084B3915]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_payment] ADD  DEFAULT ((99)) FOR [sort_id]
GO
/****** Object:  Default [DF__shop_paym__is_lo__093F5D4E]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_payment] ADD  DEFAULT ((0)) FOR [is_lock]
GO
/****** Object:  Default [DF__shop_sale__title__0A338187]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_sales] ADD  DEFAULT ('') FOR [title]
GO
/****** Object:  Default [DF__shop_sale__sub_t__0B27A5C0]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_sales] ADD  DEFAULT ('') FOR [sub_title]
GO
/****** Object:  Default [DF__shop_sale__img_u__0C1BC9F9]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_sales] ADD  DEFAULT ('') FOR [img_url]
GO
/****** Object:  Default [DF__shop_sales__type__0D0FEE32]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_sales] ADD  DEFAULT ('') FOR [type]
GO
/****** Object:  Default [DF__shop_sale__quant__0E04126B]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_sales] ADD  DEFAULT ((0)) FOR [quantity]
GO
/****** Object:  Default [DF__shop_sale__amoun__0EF836A4]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_sales] ADD  DEFAULT ((0)) FOR [amount]
GO
/****** Object:  Default [DF__shop_sale__start__0FEC5ADD]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_sales] ADD  DEFAULT (getdate()) FOR [start_time]
GO
/****** Object:  Default [DF__shop_sale__end_t__10E07F16]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_sales] ADD  DEFAULT (getdate()) FOR [end_time]
GO
/****** Object:  Default [DF__shop_sale__sort___11D4A34F]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_sales] ADD  DEFAULT ((99)) FOR [sort_id]
GO
/****** Object:  Default [DF__shop_sale__statu__12C8C788]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_sales] ADD  DEFAULT ((0)) FOR [status]
GO
/****** Object:  Default [DF__shop_sale__summa__13BCEBC1]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_sales] ADD  DEFAULT ('') FOR [summary]
GO
/****** Object:  Default [DF__shop_slid__brand__14B10FFA]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_slide] ADD  DEFAULT ((0)) FOR [brand_id]
GO
/****** Object:  Default [DF__shop_stor__title__1975C517]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_store] ADD  DEFAULT ('') FOR [title]
GO
/****** Object:  Default [DF__shop_stor__area___1A69E950]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_store] ADD  DEFAULT ((0)) FOR [area_id]
GO
/****** Object:  Default [DF__shop_stor__brand__1B5E0D89]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_store] ADD  DEFAULT ('') FOR [brand_id]
GO
/****** Object:  Default [DF__shop_stor__addre__1C5231C2]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_store] ADD  DEFAULT ('') FOR [address]
GO
/****** Object:  Default [DF__shop_store__tel__1D4655FB]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_store] ADD  DEFAULT ('') FOR [tel]
GO
/****** Object:  Default [DF__shop_stor__flags__1E3A7A34]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_store] ADD  DEFAULT ((0)) FOR [flagship]
GO
/****** Object:  Default [DF__shop_stor__coord__1F2E9E6D]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_store] ADD  DEFAULT ('') FOR [coordinate]
GO
/****** Object:  Default [DF__shop_user__payme__2022C2A6]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_user_amount_log] ADD  DEFAULT ((0)) FOR [payment_id]
GO
/****** Object:  Default [DF__shop_user__value__2116E6DF]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_user_amount_log] ADD  DEFAULT ((0)) FOR [value]
GO
/****** Object:  Default [DF__shop_user__remar__220B0B18]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_user_amount_log] ADD  DEFAULT ('') FOR [remark]
GO
/****** Object:  Default [DF__shop_user__add_t__22FF2F51]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_user_amount_log] ADD  DEFAULT (getdate()) FOR [add_time]
GO
/****** Object:  Default [DF__shop_user__artic__27C3E46E]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_user_group_price] ADD  DEFAULT ((0)) FOR [article_id]
GO
/****** Object:  Default [DF__shop_user__group__28B808A7]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_user_group_price] ADD  DEFAULT ((0)) FOR [group_id]
GO
/****** Object:  Default [DF__shop_user__price__29AC2CE0]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_user_group_price] ADD  DEFAULT ((0)) FOR [price]
GO
/****** Object:  Default [DF__shop_user__title__2AA05119]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_user_groups] ADD  DEFAULT ('') FOR [title]
GO
/****** Object:  Default [DF__shop_user__grade__2B947552]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_user_groups] ADD  DEFAULT ((0)) FOR [grade]
GO
/****** Object:  Default [DF__shop_user__upgra__2C88998B]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_user_groups] ADD  DEFAULT ((0)) FOR [upgrade_exp]
GO
/****** Object:  Default [DF__shop_user__amoun__2D7CBDC4]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_user_groups] ADD  DEFAULT ((0)) FOR [amount]
GO
/****** Object:  Default [DF__shop_user__point__2E70E1FD]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_user_groups] ADD  DEFAULT ((0)) FOR [point]
GO
/****** Object:  Default [DF__shop_user__is_de__2F650636]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_user_groups] ADD  DEFAULT ((0)) FOR [is_default]
GO
/****** Object:  Default [DF__shop_user__is_up__30592A6F]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_user_groups] ADD  DEFAULT ((1)) FOR [is_upgrade]
GO
/****** Object:  Default [DF__shop_user__is_lo__314D4EA8]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_user_groups] ADD  DEFAULT ((0)) FOR [is_lock]
GO
/****** Object:  Default [DF__shop_user__user___324172E1]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_user_login_log] ADD  DEFAULT ('') FOR [user_name]
GO
/****** Object:  Default [DF__shop_user__remar__3335971A]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_user_login_log] ADD  DEFAULT ('') FOR [remark]
GO
/****** Object:  Default [DF__shop_user__login__3429BB53]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_user_login_log] ADD  DEFAULT (getdate()) FOR [login_time]
GO
/****** Object:  Default [DF__shop_user__login__351DDF8C]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_user_login_log] ADD  DEFAULT ('') FOR [login_ip]
GO
/****** Object:  Default [DF__shop_user__oauth__38EE7070]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_user_oauth] ADD  DEFAULT ('0') FOR [oauth_name]
GO
/****** Object:  Default [DF__shop_user__add_t__39E294A9]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_user_oauth] ADD  DEFAULT (getdate()) FOR [add_time]
GO
/****** Object:  Default [DF__shop_user__add_t__408F9238]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_user_point_log] ADD  DEFAULT (getdate()) FOR [add_time]
GO
/****** Object:  Default [DF__shop_user__mobil__4460231C]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_users] ADD  DEFAULT ('') FOR [mobile]
GO
/****** Object:  Default [DF__shop_user__email__45544755]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_users] ADD  DEFAULT ('') FOR [email]
GO
/****** Object:  Default [DF__shop_user__avata__46486B8E]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_users] ADD  DEFAULT ('') FOR [avatar]
GO
/****** Object:  Default [DF__shop_user__nick___473C8FC7]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_users] ADD  DEFAULT ('') FOR [nick_name]
GO
/****** Object:  Default [DF__shop_users__sex__4830B400]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_users] ADD  DEFAULT ('') FOR [sex]
GO
/****** Object:  Default [DF__shop_user__telph__4924D839]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_users] ADD  DEFAULT ('') FOR [telphone]
GO
/****** Object:  Default [DF__shop_users__area__4A18FC72]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_users] ADD  DEFAULT ('') FOR [area]
GO
/****** Object:  Default [DF__shop_user__addre__4B0D20AB]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_users] ADD  DEFAULT ('') FOR [address]
GO
/****** Object:  Default [DF__shop_users__qq__4C0144E4]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_users] ADD  DEFAULT ('') FOR [qq]
GO
/****** Object:  Default [DF__shop_users__msn__4CF5691D]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_users] ADD  DEFAULT ('') FOR [msn]
GO
/****** Object:  Default [DF__shop_user__amoun__4DE98D56]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_users] ADD  DEFAULT ((0)) FOR [amount]
GO
/****** Object:  Default [DF__shop_user__point__4EDDB18F]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_users] ADD  DEFAULT ((0)) FOR [point]
GO
/****** Object:  Default [DF__shop_users__exp__4FD1D5C8]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_users] ADD  DEFAULT ((0)) FOR [exp]
GO
/****** Object:  Default [DF__shop_user__statu__50C5FA01]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_users] ADD  DEFAULT ((0)) FOR [status]
GO
/****** Object:  Default [DF__shop_user__reg_t__51BA1E3A]    Script Date: 08/29/2018 16:35:25 ******/
ALTER TABLE [dbo].[shop_users] ADD  DEFAULT (getdate()) FOR [reg_time]
GO
