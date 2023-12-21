// Package weather provides a Go API for weather forecast information.
package weather

// CurrentCondition holds the current weather condition.
var CurrentCondition string

// CurrentLocation holds the current location.
var CurrentLocation string

// Forecast returns a human readable sentence describing the weather condition for the given city.
func Forecast(city, condition string) string {
	CurrentLocation, CurrentCondition = city, condition
	return CurrentLocation + " - current weather condition: " + CurrentCondition
}
