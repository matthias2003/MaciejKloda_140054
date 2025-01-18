CREATE TABLE [dbo].[Cars] (
    [ID]        INT           NOT NULL,
    [Brand]     NVARCHAR (50) NOT NULL,
    [Model]     NVARCHAR (50) NOT NULL,
    [VinNumber] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Cars] PRIMARY KEY CLUSTERED ([ID] ASC)
);

