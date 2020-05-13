IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200402092001_TablaNueva')
BEGIN
    CREATE TABLE [t_AdressenTyp] (
        [adtTyp] int NOT NULL,
        [adtBezeichnung] varchar(30) NOT NULL,
        CONSTRAINT [PK_t_AdressenTyp] PRIMARY KEY NONCLUSTERED ([adtTyp])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200402092001_TablaNueva')
BEGIN
    CREATE TABLE [t_Anrede] (
        [anrAnredeID] int NOT NULL,
        [anrAnrede] varchar(15) NOT NULL,
        [anrJNPerson] tinyint NOT NULL,
        CONSTRAINT [PK_t_Anrede] PRIMARY KEY NONCLUSTERED ([anrAnredeID])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200402092001_TablaNueva')
BEGIN
    CREATE TABLE [t_BegStatus] (
        [bstStatus] int NOT NULL,
        [bstBezeichnung] varchar(30) NOT NULL,
        CONSTRAINT [PK_t_BeguenstigtenStatus] PRIMARY KEY NONCLUSTERED ([bstStatus])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200402092001_TablaNueva')
BEGIN
    CREATE TABLE [t_EinrichtungTypen] (
        [eitTyp] tinyint NOT NULL,
        [eitBezeichnung] varchar(40) NOT NULL,
        CONSTRAINT [PK_t_EinrichtungTypen] PRIMARY KEY NONCLUSTERED ([eitTyp])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200402092001_TablaNueva')
BEGIN
    CREATE TABLE [t_Versorgungstypen] (
        [vetTyp] tinyint NOT NULL,
        [vetBezeichnung] varchar(30) NOT NULL,
        CONSTRAINT [PK_t_Versorgungstypen] PRIMARY KEY NONCLUSTERED ([vetTyp])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200402092001_TablaNueva')
BEGIN
    CREATE TABLE [t_ZusagenStatus] (
        [zstStatus] tinyint NOT NULL,
        [zstBezeichnung] varchar(30) NOT NULL,
        CONSTRAINT [PK_t_ZusagenStatus] PRIMARY KEY NONCLUSTERED ([zstStatus])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200402092001_TablaNueva')
BEGIN
    CREATE TABLE [t_Adressen] (
        [adrAdresse] varchar(20) NOT NULL,
        [adrMandant] varchar(20) NOT NULL,
        [adrVorname] varchar(100) NULL,
        [adrName] varchar(100) NOT NULL,
        [adrTitel] varchar(20) NULL,
        [adrStrasse] varchar(100) NULL,
        [adrPLZ] varchar(10) NULL,
        [adrOrt] varchar(100) NULL,
        [adrAnrede] int NULL,
        [adrGDatum] datetime NULL,
        [adrTyp] int NOT NULL,
        CONSTRAINT [PK_t_Adressen] PRIMARY KEY NONCLUSTERED ([adrAdresse]),
        CONSTRAINT [FK_Adressen_hat_die_Anrede] FOREIGN KEY ([adrAnrede]) REFERENCES [t_Anrede] ([anrAnredeID]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Adressen_hat_AdrTyp] FOREIGN KEY ([adrTyp]) REFERENCES [t_AdressenTyp] ([adtTyp]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200402092001_TablaNueva')
BEGIN
    CREATE TABLE [t_VereinbarungenDetails] (
        [vedID] varchar(20) NOT NULL,
        [vedLeistungsgruppe] varchar(20) NOT NULL,
        [vedVersorgungstyp] tinyint NOT NULL,
        CONSTRAINT [PK_t_VereinbarungenDetails] PRIMARY KEY NONCLUSTERED ([vedID]),
        CONSTRAINT [FK_VereinbarungenDetails_hat_Typen] FOREIGN KEY ([vedVersorgungstyp]) REFERENCES [t_Versorgungstypen] ([vetTyp]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200402092001_TablaNueva')
BEGIN
    CREATE TABLE [t_Einrichtung] (
        [einID] varchar(20) NOT NULL,
        [einAdresse] varchar(20) NULL,
        [einTyp] tinyint NULL,
        [einBezeichnung] varchar(100) NULL,
        CONSTRAINT [PK_t_Einrichtung] PRIMARY KEY ([einID]),
        CONSTRAINT [FK_Einrichtung_hat_die_Adresse] FOREIGN KEY ([einAdresse]) REFERENCES [t_Adressen] ([adrAdresse]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Einrichtung_ist_vom_Typ] FOREIGN KEY ([einTyp]) REFERENCES [t_EinrichtungTypen] ([eitTyp]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200402092001_TablaNueva')
BEGIN
    CREATE TABLE [t_Mandanten] (
        [manMandant] varchar(20) NOT NULL,
        [manEinrichtung] varchar(20) NOT NULL,
        [manAdresse] varchar(20) NULL,
        [manBezeichnung] varchar(50) NOT NULL,
        CONSTRAINT [PK_t_Mandanten] PRIMARY KEY NONCLUSTERED ([manMandant]),
        CONSTRAINT [FK_Mandanten_hat_Einrichtung] FOREIGN KEY ([manEinrichtung]) REFERENCES [t_Einrichtung] ([einID]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200402092001_TablaNueva')
BEGIN
    CREATE TABLE [t_Mitglieder] (
        [mitMitglied] varchar(20) NOT NULL,
        [mitMandant] varchar(20) NULL,
        [mitAdresse] varchar(20) NOT NULL,
        CONSTRAINT [PK_t_Mitglieder] PRIMARY KEY NONCLUSTERED ([mitMitglied]),
        CONSTRAINT [FK_Mitglieder_hat_die_Adresse] FOREIGN KEY ([mitAdresse]) REFERENCES [t_Adressen] ([adrAdresse]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Mitglieder_ist_vom_Mandant] FOREIGN KEY ([mitMandant]) REFERENCES [t_Mandanten] ([manMandant]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200402092001_TablaNueva')
BEGIN
    CREATE TABLE [t_Beguenstigte] (
        [begBeguenstigter] varchar(20) NOT NULL,
        [begMitglied] varchar(20) NOT NULL,
        [begAdresse] varchar(20) NOT NULL,
        [begStatus] int NOT NULL,
        [begPersonalNr] varchar(20) NULL,
        [begEintrittsdatum] datetime NULL,
        CONSTRAINT [PK_t_Beguenstigte] PRIMARY KEY ([begBeguenstigter]),
        CONSTRAINT [FK_Begungstigte_hat_die_Adresse] FOREIGN KEY ([begAdresse]) REFERENCES [t_Adressen] ([adrAdresse]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Begungstigte_hat_Mitglieder] FOREIGN KEY ([begMitglied]) REFERENCES [t_Mitglieder] ([mitMitglied]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Begungstigte_hat_Status] FOREIGN KEY ([begStatus]) REFERENCES [t_BegStatus] ([bstStatus]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200402092001_TablaNueva')
BEGIN
    CREATE TABLE [t_Vereinbarungen] (
        [verVereinbarung] varchar(20) NOT NULL,
        [verMitglied] varchar(20) NOT NULL,
        [verGueltigAb] datetime NOT NULL,
        [verGueltigBis] datetime NULL,
        [verBezeichnung] varchar(100) NULL,
        CONSTRAINT [PK_t_Vereinbarungen] PRIMARY KEY NONCLUSTERED ([verVereinbarung]),
        CONSTRAINT [FK_Vereinbarungen_hat_Mitglied] FOREIGN KEY ([verMitglied]) REFERENCES [t_Mitglieder] ([mitMitglied]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200402092001_TablaNueva')
BEGIN
    CREATE TABLE [t_VereinbarLeistgruppen] (
        [vlgLeistungsgruppe] varchar(20) NOT NULL,
        [vlgVereinbarung] varchar(20) NOT NULL,
        [vlgBezeichnung] varchar(50) NOT NULL,
        [vlgAV] bit NOT NULL,
        [vlgWuWRente] bit NOT NULL,
        [vlgTodesfall] bit NOT NULL,
        [vlgInvaliditaet] bit NOT NULL,
        CONSTRAINT [PK_t_VereinbarungenLeistungsgruppen] PRIMARY KEY NONCLUSTERED ([vlgLeistungsgruppe]),
        CONSTRAINT [FK_VereinbarLeistgruppen_hat_Vereinbarung] FOREIGN KEY ([vlgVereinbarung]) REFERENCES [t_Vereinbarungen] ([verVereinbarung]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200402092001_TablaNueva')
BEGIN
    CREATE TABLE [t_Zusagen] (
        [zusZusage] varchar(20) NOT NULL,
        [zusBeguenstigter] varchar(20) NOT NULL,
        [zusLeistungsgruppe] varchar(20) NOT NULL,
        [zusGueltigAb] datetime NULL,
        CONSTRAINT [PK_t_Zusagen] PRIMARY KEY NONCLUSTERED ([zusZusage]),
        CONSTRAINT [FK_Zusagen_hat_Beguenstigte] FOREIGN KEY ([zusBeguenstigter]) REFERENCES [t_Beguenstigte] ([begBeguenstigter]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Zusagen_hat_VerLeistunGrup] FOREIGN KEY ([zusLeistungsgruppe]) REFERENCES [t_VereinbarLeistgruppen] ([vlgLeistungsgruppe]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200402092001_TablaNueva')
BEGIN
    CREATE TABLE [t_ZusagenDetails] (
        [zudID] varchar(20) NOT NULL,
        [zudZusage] varchar(20) NOT NULL,
        [zudVersorgungstyp] tinyint NOT NULL,
        [zudGueltigAb] datetime NOT NULL,
        [zudStatus] tinyint NOT NULL,
        [zudWertEin] money NOT NULL,
        [zudWertAus] money NOT NULL,
        CONSTRAINT [PK_t_ZusagenDetails] PRIMARY KEY NONCLUSTERED ([zudID]),
        CONSTRAINT [FK_ZusagenDetails_hat_Status] FOREIGN KEY ([zudStatus]) REFERENCES [t_ZusagenStatus] ([zstStatus]) ON DELETE NO ACTION,
        CONSTRAINT [FK_ZusagenDetails_zum_versorgTyp] FOREIGN KEY ([zudVersorgungstyp]) REFERENCES [t_Versorgungstypen] ([vetTyp]) ON DELETE NO ACTION,
        CONSTRAINT [FK_ZusagenDetails_kpmm_von_Zug] FOREIGN KEY ([zudZusage]) REFERENCES [t_Zusagen] ([zusZusage]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200402092001_TablaNueva')
BEGIN
    CREATE INDEX [IX_t_Adressen_adrAnrede] ON [t_Adressen] ([adrAnrede]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200402092001_TablaNueva')
BEGIN
    CREATE INDEX [IX_t_Adressen_adrTyp] ON [t_Adressen] ([adrTyp]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200402092001_TablaNueva')
BEGIN
    CREATE INDEX [IX_t_Beguenstigte_begAdresse] ON [t_Beguenstigte] ([begAdresse]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200402092001_TablaNueva')
BEGIN
    CREATE INDEX [IX_t_Beguenstigte_begMitglied] ON [t_Beguenstigte] ([begMitglied]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200402092001_TablaNueva')
BEGIN
    CREATE INDEX [IX_t_Beguenstigte_begStatus] ON [t_Beguenstigte] ([begStatus]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200402092001_TablaNueva')
BEGIN
    CREATE INDEX [IX_t_Einrichtung_einAdresse] ON [t_Einrichtung] ([einAdresse]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200402092001_TablaNueva')
BEGIN
    CREATE INDEX [IX_t_Einrichtung_einTyp] ON [t_Einrichtung] ([einTyp]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200402092001_TablaNueva')
BEGIN
    CREATE INDEX [IX_t_Mandanten_manEinrichtung] ON [t_Mandanten] ([manEinrichtung]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200402092001_TablaNueva')
BEGIN
    CREATE INDEX [IX_t_Mitglieder_mitAdresse] ON [t_Mitglieder] ([mitAdresse]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200402092001_TablaNueva')
BEGIN
    CREATE INDEX [IX_t_Mitglieder_mitMandant] ON [t_Mitglieder] ([mitMandant]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200402092001_TablaNueva')
BEGIN
    CREATE INDEX [IX_t_VereinbarLeistgruppen_vlgVereinbarung] ON [t_VereinbarLeistgruppen] ([vlgVereinbarung]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200402092001_TablaNueva')
BEGIN
    CREATE INDEX [IX_t_Vereinbarungen_verMitglied] ON [t_Vereinbarungen] ([verMitglied]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200402092001_TablaNueva')
BEGIN
    CREATE INDEX [IX_t_VereinbarungenDetails_vedVersorgungstyp] ON [t_VereinbarungenDetails] ([vedVersorgungstyp]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200402092001_TablaNueva')
BEGIN
    CREATE INDEX [IX_t_Zusagen_zusBeguenstigter] ON [t_Zusagen] ([zusBeguenstigter]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200402092001_TablaNueva')
BEGIN
    CREATE INDEX [IX_t_Zusagen_zusLeistungsgruppe] ON [t_Zusagen] ([zusLeistungsgruppe]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200402092001_TablaNueva')
BEGIN
    CREATE INDEX [IX_t_ZusagenDetails_zudStatus] ON [t_ZusagenDetails] ([zudStatus]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200402092001_TablaNueva')
BEGIN
    CREATE INDEX [IX_t_ZusagenDetails_zudVersorgungstyp] ON [t_ZusagenDetails] ([zudVersorgungstyp]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200402092001_TablaNueva')
BEGIN
    CREATE INDEX [IX_t_ZusagenDetails_zudZusage] ON [t_ZusagenDetails] ([zudZusage]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200402092001_TablaNueva')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200402092001_TablaNueva', N'2.2.6-servicing-10079');
END;

GO

