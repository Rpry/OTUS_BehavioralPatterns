using System;

namespace BehPatterns.Memento.DocumentStateSavingWithMemento
{
    // Базовый нетипизированный контракт снимка. Нужен, чтобы Caretaker мог хранить
    // разнородные снимки в одной коллекции, не зная конкретного типа состояния.
    // Идентификатор позволяет отличать «свои» снимки от чужих и prevents восстановление
    // снимка, принадлежащего другому originator-у.
    public interface IMemento
    {
        // Кому принадлежит снимок — originator сам проверяет при restore, что это его снимок.
        string OriginatorId { get; }

        // Когда сделан — для метаданных истории и отладки.
        DateTime CreatedAt { get; }

        // Размер состояния в байтах (грубая оценка) — для учёта памяти.
        long SizeBytes { get; }
    }

    // Типизированный снимок: состояние доступно только через явный доступ, и только
    // originator знает, как его интерпретировать. Внешний код не должен дотягиваться
    // до внутренностей состояния — поэтому State отдаётся через метод с пометкой,
    // что это контракт originator-а, а не публичный API.
    public interface IMemento<out TState> : IMemento
    {
        TState GetState();
    }
}
