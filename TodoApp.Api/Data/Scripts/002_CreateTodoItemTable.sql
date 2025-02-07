CREATE TABLE TodoItem
(
    Id           TEXT PRIMARY KEY,
    Title        TEXT    NOT NULL,
    Description  TEXT,
    Status       INTEGER NOT NULL DEFAULT 0,
    CreatedAt    TEXT    NOT NULL,
    UpdatedAt    TEXT    NOT NULL,
    DueAt        TEXT,
    CompletedAt  TEXT,
    DeletedAt    TEXT,
    CreatedById  TEXT    NOT NULL,
    AssignedToId TEXT,
    FOREIGN KEY (CreatedById) REFERENCES Users (Id),
    FOREIGN KEY (AssignedToId) REFERENCES Users (Id)
);
