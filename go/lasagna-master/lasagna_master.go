package lasagna

func PreparationTime(layers []string, time int) int {
	if time == 0 {
		time = 2
	}
	return len(layers) * time
}

func Quantities(layers []string) (noodles int, sauce float64) {
	sauce_count := 0
	noodles_count := 0
	for _, layer := range layers {
		if layer == "sauce" {
			sauce_count++
		}
		if layer == "noodles" {
			noodles_count++
		}
	}
	sauce = 0.2 * float64(sauce_count)
	noodles = 50 * noodles_count
	return
}

func AddSecretIngredient(friendsList []string, myList []string) {
	myList[len(myList)-1] = friendsList[len(friendsList)-1]
}

func ScaleRecipe(quantities []float64, portions int) []float64 {
	newQuantities := make([]float64, len(quantities))
	copy(newQuantities, quantities)
	multiplier := float64(portions) / 2
	for i, quantity := range quantities {
		newQuantities[i] = quantity * multiplier
	}
	return newQuantities
}
