# .net6-jwt-token
jwt token in .net 6.0
Create and use jwt token in .net 6.0. Authentication and authorization with DB
# using entityframework core to validate user from sql db



![image](https://user-images.githubusercontent.com/85626647/193739137-73353cdf-4661-4897-8c62-59553b8d109e.png)


# Sql table
CREATE TABLE [dbo].[UserInfo](
	[UserId] [nvarchar](200) NOT NULL,
	[EmailId] [nvarchar](50) NULL,
	[UserName] [nvarchar](100) NULL,
	[CompanyId] [int] NOT NULL,
	[Location] [int] NULL,
	[IsActive] [bit] NULL,
	[Roles] [nvarchar](200) NULL,
 CONSTRAINT [PK_UserInfo] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
