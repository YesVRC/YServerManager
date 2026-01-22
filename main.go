package main

import (
	"embed"
	"net/http"

	"github.com/YesVRC/YServerManager/components"
	"github.com/YesVRC/YServerManager/middleware"
	"github.com/a-h/templ"
)

//go:embed assets
var assets embed.FS

func main() {
	s := http.NewServeMux()
	s.HandleFunc("GET /", func(w http.ResponseWriter, r *http.Request) {
		templ.Handler(components.Hello(
			components.PageMetadata{
				Title: "Hello",
				Path:  r.URL.Path,
			},
			"Yes")).ServeHTTP(w, r)
	})
	s.Handle("GET /assets/", http.FileServer(http.FS(assets)))

	if err := http.ListenAndServe(":8080", middleware.LoggerMiddleware(s)); err != nil {
		panic(err)
	}
}
