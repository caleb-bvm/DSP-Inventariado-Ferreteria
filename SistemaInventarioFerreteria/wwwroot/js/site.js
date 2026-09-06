(() => {
    const body = document.body;
    const sidebar = document.getElementById("app-navigation");
    const openButton = document.querySelector("[data-nav-open]");
    const closeButtons = document.querySelectorAll("[data-nav-close]");
    const scrim = document.querySelector(".nav-scrim");

    document.querySelectorAll(".table-scroll table").forEach((table) => {
        const headings = Array.from(table.querySelectorAll("thead th"), (heading) =>
            heading.textContent.trim()
        );

        table.querySelectorAll("tbody tr").forEach((row) => {
            Array.from(row.children).forEach((cell, index) => {
                if (!cell.hasAttribute("data-label") && headings[index]) {
                    cell.setAttribute("data-label", headings[index]);
                }
            });
        });
    });

    if (!sidebar || !openButton) return;

    const media = window.matchMedia("(min-width: 1025px)");

    const setNavigation = (open) => {
        const shouldOpen = !media.matches && open;
        body.classList.toggle("nav-open", shouldOpen);
        openButton.setAttribute("aria-expanded", String(shouldOpen));
        sidebar.toggleAttribute("inert", !media.matches && !shouldOpen);
        sidebar.setAttribute("aria-hidden", String(!media.matches && !shouldOpen));
        if (scrim) scrim.hidden = !shouldOpen;
        if (shouldOpen) sidebar.querySelector("a, button")?.focus();
    };

    openButton.addEventListener("click", () => setNavigation(true));
    closeButtons.forEach((button) => button.addEventListener("click", () => setNavigation(false)));

    document.addEventListener("keydown", (event) => {
        if (event.key === "Escape" && body.classList.contains("nav-open")) setNavigation(false);
    });

    sidebar.querySelectorAll("a").forEach((link) => {
        link.addEventListener("click", () => {
            if (!media.matches) setNavigation(false);
        });
    });

    document.querySelectorAll(".nav-item.is-disabled").forEach((item) => {
        item.addEventListener("click", (event) => event.preventDefault());
    });
    document.querySelectorAll('[aria-disabled="true"][href="#"]').forEach((item) => {
        item.addEventListener("click", (event) => event.preventDefault());
    });

    media.addEventListener("change", (event) => {
        if (event.matches) {
            body.classList.remove("nav-open");
            openButton.setAttribute("aria-expanded", "false");
            sidebar.removeAttribute("inert");
            sidebar.setAttribute("aria-hidden", "false");
        } else {
            setNavigation(false);
        }
    });

    setNavigation(false);
})();
