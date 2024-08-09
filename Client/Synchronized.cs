﻿namespace MonogameTetrisClient;

public class Synchronized<T> {
    private readonly object _lock = new();
    private T _value;

    public delegate TResult Accessor<out TResult>(ref T value);

    public Synchronized(T value) {
        _value = value;
    }

    public TResult Access<TResult>(Accessor<TResult> accessor) {
        lock (_lock) {
            return accessor(ref _value);
        }
    }
}
