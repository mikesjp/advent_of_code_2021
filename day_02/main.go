package main

import (
	"os"
	"fmt"
	"bufio"
	"strings"
	"strconv"
)

func main() {
	inputs, err := readFile("input.txt")
	if err != nil {
		fmt.Println(err)
	}

	var horizontalPosition int
	var depth int

	for _, input := range inputs {

		split := strings.Split(input, " ")
		instruction := split[0]
		value, _ := strconv.Atoi(split[1])
		switch (instruction) {
			case "down":
				depth += value
			case "up":
				depth -= value
			case "forward":
				horizontalPosition += value
		}
	}

	fmt.Println(horizontalPosition * depth)
}

func readFile(path string) ([]string, error) {
	file, err := os.Open(path)
	if err != nil {
		return nil, err
	}
	defer file.Close()

	var inputs []string
	scanner := bufio.NewScanner(file)
	for scanner.Scan() {
		inputs = append(inputs, scanner.Text())
	}
	return inputs, scanner.Err()
}