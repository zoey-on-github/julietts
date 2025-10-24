package main

//import "github.com/bwmarrin/discordgo"
import (
	"fmt"
	"os/exec"
)

func main() {
	program := "touch"
	arg0 := "test"
	exec.Command(program, arg0)
	fmt.Println("test")
}
