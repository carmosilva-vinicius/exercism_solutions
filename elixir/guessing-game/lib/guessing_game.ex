defmodule GuessingGame do
  def compare(secret_number, guess \\ :no_guess)

  def compare(_, :no_guess) do
    "Make a guess"
  end

  def compare(secret_number, guess) 
  when secret_number == guess do
    "Correct"
  end

  def compare(secret_number, guess) 
  when (secret_number + 1) == guess or (secret_number - 1) == guess do
    "So close"
  end

  def compare(secret_number, guess) 
  when (secret_number + 1) < guess do
    "Too high"
  end

  def compare(secret_number, guess) 
  when (secret_number - 1) > guess do
    "Too low"
  end
end
