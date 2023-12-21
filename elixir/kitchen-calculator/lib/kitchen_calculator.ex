defmodule KitchenCalculator do
  def get_volume(volume_pair) do
    {_, volume} = volume_pair
    volume
  end

  def to_milliliter(volume_pair) do
    {unit, volume} = volume_pair
    milliliter_volume = case unit do
      :milliliter -> volume
      :teaspoon -> volume * 5
      :tablespoon -> volume * 15
      :cup -> volume * 240
      :fluid_ounce -> volume * 30
    end
    {:milliliter, milliliter_volume}
  end

  def from_milliliter(volume_pair, unit) do
    {_, volume} = volume_pair
    converted_volume = case unit do
      :milliliter -> volume
      :teaspoon -> volume / 5
      :tablespoon -> volume / 15
      :cup -> volume / 240
      :fluid_ounce -> volume / 30
    end
    {unit, converted_volume}
  end

  def convert(volume_pair, unit) do
    ml_volume = to_milliliter(volume_pair)
    from_milliliter(ml_volume, unit)
  end
end
