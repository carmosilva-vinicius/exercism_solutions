defmodule FreelancerRates do
  def daily_rate(hourly_rate) do
    hourly_rate * 8.0
  end

  def apply_discount(before_discount, discount) do
    before_discount * (1 - discount/100)
  end

  def monthly_rate(hourly_rate, discount) do 
    hourly_rate
    |> daily_rate() 
    |> then(&(&1 * 22))
    |> apply_discount(discount)
    |> Float.ceil()
    |> trunc()
  end

  def days_in_budget(budget, hourly_rate, discount) do
    daily = hourly_rate
    |> daily_rate()
    budget
    |> then(&(&1 / daily))
    |> then(&(&1 * (1 + discount/100)))
    |> then(&(&1 + 0.000000001))
    |> Float.floor(1)
  end
end
