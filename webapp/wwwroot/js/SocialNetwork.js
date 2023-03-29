/*
Again I couldn't get MVC or DbContext to work so I had to resort to Javascript.
As JS has the option of functional or OOP, I was still able to use inhreitance for
post classes. I also used Set() which is the equalivant of List<T> in C#
*/

class Post {
    constructor(id, username, message) {
        this.id = id
        this.username = username
        this.message = message
        this.messageType = this.constructor.name
        this.timestamp = Date.now()
        this.likes = 0
        this.comments = []
    }
    Like() {
        this.likes++
    }
    Unlike() {
        this.likes--
    }
    AddComment(info) {
        this.comments.push(info)
    }
}
class MessagePost extends Post {
    constructor(id, data) {
        super(id, data.username, data.message)
    }
}
class PhotoPost extends Post {
    constructor(id, data) {
        super(id, data.username, data.message)
        this.fileName = data.fileName
    }
}

/*
Class for interacting with the DOM
*/
class Page {
    constructor() {
    }
    addPost(data) {
        var commentData = ''
        data.comments.forEach(comment => commentData += 'User: ' + comment.username + ' Message: ' + comment.message)
        document.getElementById('Post').insertAdjacentHTML('afterend', `
        <tr id="Post${data.id}">
             <td>${data.id}</td>
             <td>${data.username}</td>
             <td>${data.messageType}</td>
             <td>${data.message}</td>
             <td>${data.likes}</td>
            <th><button id="${data.id}" type="button" onclick="LikeUnlike(this.id, this.innerText, this)">Like</button></th>
            <th><button id="${data.id}" type="button" onclick="addComment(this.id)">Add Comment</button></th>
            <td>${commentData}</td>
        </tr>
    `)
    }
    RemovePost(id) {
        document.getElementById('Post' + id).remove()
    }
    display(posts) {
        document.getElementById('allPosts').innerHTML = `
            <caption>All Posts</caption>
                <tr id="Post" style="background-color: sienna">
                    <th>Post ID</th>
                    <th>Author</th>
                    <th>Message Type</th>
                    <th>Message</th>
                    <th>Likes</th>
                </tr>
        `
        posts.forEach(post => this.addPost(post))
    }
}




class NewsFeed extends Page {
    constructor() {
        super()
        this.posts = new Set()
        this.postTypes = {
            message: MessagePost,
            photo: PhotoPost
        }
        this.ID = 0
        this.populate()
    }
    populate() {
        for (let i = 0; i < 10; i++) {
            this.AddPost({ username: 'lukas', message: 'hello', type: 'message' })
        }
        this.RemovePost('id', 30)
        super.display(this.posts)
        this.ChangePost(5, 'AddComment', { username: 'lukas', message: 'hello' })
        
    }
    /*
     * {
     * type: 'message', 'photo',
     * username: name,
     * message: message,
     * fileName: filename
     * }
     */
    AddPost(data) {
        this.posts.add(new this.postTypes[data.type](++this.ID, data))
        super.display(this.posts)
    }
    RemovePost(type, data) {
        if (type === 'all') this.posts.clear()
        this.posts.forEach(post => {
            if (post[type] === data) this.posts.delete(post)
        })
    }
    GetPosts(type, data) { // type: message username id timestamp
        if (type === 'all') return this.posts
        var posts = new Set()
        for (const post of this.posts.values())
            if (post[type] === data) posts.add(post)
        return posts
    }
    // Like Unlike Addcomment
    ChangePost(id, type, args) {
        this.GetPosts('id', parseInt(id)).forEach(post => post[type](args))
        super.display(this.posts)
    }

}
window.news = new NewsFeed()
function getId(id) {
    return document.getElementById(id)
}
function LikeUnlike(id, type, element) {
    var oldElement = getId(id).innerText
    window.news.ChangePost(id, type)
    if (oldElement === 'Like') getId(id).innerText = 'Unlike'
    if (oldElement === 'Unlike') getId(id).innerText = 'Like'
}
function messageTypeChange() {
    var typeElement = getId('MessageType').value
    if (typeElement === 'photo') getId('MessageFileName').disabled = false
    else getId('MessageFileName').disabled = true
}
function addPost() {
    var data = {
        username: getId('MessageUserName').value,
        type: getId('MessageType').value,
        message: getId('MessageValue').value,
        fileName: getId('MessageFileName').value
    }
    window.news.AddPost(data)
}
function addComment(id) {
    var comment = prompt('Enter comment')
    window.news.ChangePost(id, 'AddComment', {username: 'lukas', message: comment})
}
