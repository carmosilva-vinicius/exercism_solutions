defmodule LogLevel do
  def to_label(level, legacy?) do
    cond do
      level == 0 and not legacy? -> :trace
      level == 1 -> :debug
      level == 2 -> :info
      level == 3 -> :warning
      level == 4 -> :error
      level ==5 and not legacy? -> :fatal
      true -> :unknown
    end
  end

  def alert_recipient(level, legacy?) do
    cond do
      level == -1 and legacy? -> :dev1
      level == 0 and legacy? -> :dev1
      level == 5 and legacy? -> :dev1
      level == 6 and legacy? -> :dev1
      level == 5 or level == 4 -> :ops
      level == 6 and not legacy? -> :dev2
      true -> false
    end
  end
end
