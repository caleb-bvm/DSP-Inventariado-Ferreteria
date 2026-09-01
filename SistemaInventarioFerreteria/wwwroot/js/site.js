(() => {
    const body = document.body;
    const sidebar = document.getElementById("app-navigation");
    const openButton = document.querySelector("[data-nav-open]");
    const closeButtons = document.querySelectorAll("[data-nav-close]");

    if (!sidebar || !openButton) return;

    const setNavigation = (open) => {
        body.classList.toggle("nav-open", open);
        openButton.setAttribute("aria-expanded", String(open));
        if (open) sidebar.querySelector("a, button")?.focus();
        else openButton.focus();
    };

    openButton.addEventListener("click", () => setNavigation(true));
    closeButtons.forEach((button) => button.addEventListener("click", () => setNavigation(false)));

    document.addEventListener("keydown", (event) => {
        if (event.key === "Escape" && body.classList.contains("nav-open")) setNavigation(false);
    });

    document.querySelectorAll(".nav-item.is-disabled").forEach((item) => {
        item.addEventListener("click", (event) => event.preventDefault());
    });
    document.querySelectorAll('[aria-disabled="true"][href="#"]').forEach((item) => {
        item.addEventListener("click", (event) => event.preventDefault());
    });

    const media = window.matchMedia("(min-width: 1025px)");
    media.addEventListener("change", (event) => {
        if (event.matches) {
            body.classList.remove("nav-open");
            openButton.setAttribute("aria-expanded", "false");
        }
    });
})();
