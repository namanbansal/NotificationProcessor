CREATE TABLE [dbo].[WebhookNotification]
(
	[Id] INT NOT NULL IDENTITY (1, 1) PRIMARY KEY, 
	[WebhookId] NVARCHAR(500) NOT NULL,
    [Payload] NVARCHAR(2000) NOT NULL, 
    [ReceivedOn] DATETIME NOT NULL, 
    
)
