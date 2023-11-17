package main

import "fmt"

type IPrimes interface {
	Clone() IPrimes
}

type Primes struct {
	Numbers    []int
	StartRange int
	EndRange   int
}

func (p *Primes) Clone() IPrimes {
	return &Primes{
		Numbers:    append([]int{}, p.Numbers...),
		StartRange: p.StartRange,
		EndRange:   p.EndRange,
	}
}

func main() {
	originalPrimes := &Primes{
		Numbers:    []int{2, 3, 5, 7, 11},
		StartRange: 1,
		EndRange:   15,
	}
	clonedPrimes := originalPrimes.Clone().(*Primes)
	clonedPrimes.Numbers = append(clonedPrimes.Numbers, 13, 17)
	clonedPrimes.StartRange = 1
	clonedPrimes.EndRange = 18

	fmt.Println("Original Primes:", originalPrimes)
	fmt.Println("Cloned Primes:", clonedPrimes)
}
